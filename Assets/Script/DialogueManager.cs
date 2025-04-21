using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance; // Instance unique pour pouvoir y accéder facilement (pattern Singleton)
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    private Queue<string> sentences;//on va mettre les phrases du dialogue dans une liste, Queue va avoir plusieurs élèments les un derriere les autres
    public Image DialogueUI;
    private Shoot shootScript;
    public DialogueTrigger dialogueTrigger;


    void Awake()
    {
        if(instance != null) // Vérifie si une autre instance existe déjà
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
        sentences.Clear(); //on vide dans le doute la liste d'attente, pour éviter que le dialogue précédent y soit encore

        foreach (string sentence in dialogue.sentences) //boucle pour mettre chacune des phrases dans la file d'attente
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //on le met en public pour le buttin continue
    {
        if(sentences.Count == 0) //si la file est vide, terminer le dialogue
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); //on récupére le prochain élément de la file d'attente
        StopAllCoroutines(); //dans le doute on stoppe d'abord toute les coroutines pour éviter une supperposition
        StartCoroutine(TypeSentence(sentence));
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
        DialogueUI.gameObject.SetActive(false); // Cache l’interface du dialogue
    }


}
