using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Référence au dialogue à jouer
    public bool isInRange; // Indique si le joueur est dans la zone de déclenchement
    private Interaction playerInteraction; // Référence au script d’interaction du joueur
    public TextMeshProUGUI interactUI; // Texte affiché quand le joueur peut interagir

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInteraction = player.GetComponent<Interaction>();
        }
    }
    void Update()
    {
        // Si le joueur est dans la zone, qu'on a une référence, et qu’il appuie sur la touche d’interaction
        if(isInRange && playerInteraction != null && playerInteraction.CanInteract())
        {
            TriggerDialogue(); // Lancer le dialogue
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) // Appelé quand un objet entre dans la zone du collider (2D)
    { 
        if(collision.CompareTag("Player")) // Si c’est le joueur qui entre
        {
            isInRange = true;
            interactUI.gameObject.SetActive(true); // Affiche l’UI d’interaction
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Appelé quand un objet sort de la zone du collider (2D)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.gameObject.SetActive(false); // Cache le texte d’interaction
        }
    }

    void TriggerDialogue() //on va rester générale/système car va être utilisé pour plusieurs npc
    {
        DialogueManager.instance.StartDialogue(dialogue); //on appelle notre manager et lance notre dialogue
    }

}
