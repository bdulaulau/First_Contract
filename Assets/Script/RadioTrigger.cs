using UnityEngine;
using System.Collections;

public class RadioTrigger : MonoBehaviour
{
    public Item talkie;
    public Dialogue dialogue;
    public bool isInRange;
    private bool hasTriggered = false;
    private int currentSentenceIndex = 0;
    void Update()
    {
        if (isInRange && !hasTriggered)
        {
            hasTriggered = true;
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Inventory.Instance.content.Contains(talkie))
        {
           isInRange = true;
     }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
      {
          isInRange = false;
      }
    }

    void TriggerDialogue()
    {
        RadioManager.instance.onDialogueEnd += OnDialogueEnd; // on s’abonne à la fin du dialogue
        RadioManager.instance.StartDialogue(dialogue);
    }

    void OnDialogueEnd()
    {
        if(currentSentenceIndex == dialogue.sentences.Length -1 )//si on atteint la derniere phrase du dialogue
        {
            RadioManager.instance.onDialogueEnd -= OnDialogueEnd; // on se désabonne proprement
            StartCoroutine(DestroyAfterDialogue());
        }
        else
        {
            currentSentenceIndex ++;
        }
    }

    private IEnumerator DestroyAfterDialogue()
    {
        yield return new WaitForSeconds(1.8f);// Attendre un moment (1 seconde) pour être sûr que le dernier texte est lu
        Destroy(gameObject); // Détruire l'objet après le délai
    }
}