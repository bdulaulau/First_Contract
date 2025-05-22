using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RadioManager : MonoBehaviour
{

    public static RadioManager instance; // Instance unique pour pouvoir y accéder facilement (pattern Singleton)
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    private Queue<string> sentences;//on va mettre les phrases du dialogue dans une liste, Queue va avoir plusieurs élèments les un derriere les autres
    public Image DialogueUI;
    private Shoot shootScript;
    public RadioTrigger radioTrigger;
    private Animator animatorTalkie;
    public Image Talkie;


    public AudioClip texteDialogue;
    public AudioClip continueDialogue;
    public AudioClip endDialogue;


    public System.Action onDialogueEnd; // on permet aux autres scripts d'écouter la fin du dialogue

    void Awake()
    {
        animatorTalkie = Talkie.GetComponent<Animator>();
        if (instance != null) // Vérifie si une autre instance existe déjà
        {
            Debug.LogWarning("Il y a plus d'une instance de dialoguemanager dans la scène");
            return;
        }
        instance = this; // Assigne l'instance actuelle comme référence globale

        sentences = new Queue<string>(); //on va initialiser notre queue
        DialogueUI.gameObject.SetActive(false); // Cache l’interface du dialogue au début

        shootScript = FindObjectOfType<Shoot>();// récupère le script Shoot attaché au joueur
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (shootScript != null) //on désactive l'arme pour éviter de tirer quand un dialogue se lance
        {
            shootScript.StatueWeaponOff(); // Désactive l’arme du joueur pendant le dialogue
        }

        DialogueUI.gameObject.SetActive(true);
        nameText.text = dialogue.name;
        AudioManager.instance.PlayClipAt(texteDialogue, transform.position);
        sentences.Clear(); //on vide dans le doute la liste d'attente, pour éviter que le dialogue précédent y soit encore

        foreach (string sentence in dialogue.sentences) //boucle pour mettre chacune des phrases dans la file d'attente
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //on le met en public pour le buttin continue
    {
        if (sentences.Count == 0) //si la file est vide, terminer le dialogue
        {
            animatorTalkie.SetBool("IsOff", true);
            StartCoroutine(WaitAndExecute());
            return;
        }

        string sentence = sentences.Dequeue(); //on récupére le prochain élément de la file d'attente
        AudioManager.instance.PlayClipAt(texteDialogue, transform.position);
        StopAllCoroutines(); //dans le doute on stoppe d'abord toute les coroutines pour éviter une supperposition
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator WaitAndExecute()
    {
        // Attendre 1 seconde
        yield return new WaitForSeconds(1.2f);
        AudioManager.instance.PlayClipAt(endDialogue, transform.position);

        // Code à exécuter après 1 seconde
        //Debug.Log("Une seconde est passée !");

        EndDialogue();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())//on découpe notre phrase en array
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.02f); //on donne une légère latence de 0.02 seconde
        }
    }

    void EndDialogue()
    {
        DialogueUI.gameObject.SetActive(false); // on cache l’interface du dialogue
        onDialogueEnd?.Invoke(); // on ignale que le dialogue est terminé
    }


}
