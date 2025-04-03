using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInRange;
    private Interaction playerInteraction;
    public TextMeshProUGUI interactUI;

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
        if(isInRange && playerInteraction != null && playerInteraction.CanInteract())
        {
            TriggerDialogue();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.gameObject.SetActive(false);
        }
    }

    void TriggerDialogue() //on va rester générale/système car va être utilisé pour plusieurs npc
    {
        DialogueManager.instance.StartDialogue(dialogue); //on appelle notre manager et lance notre dialogue
    }

}
