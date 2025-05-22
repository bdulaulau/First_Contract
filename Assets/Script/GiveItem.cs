using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GiveItem : MonoBehaviour
{

    public bool isInRange;
    public Item item;
    public bool DestroyGiver;
    public AudioClip feedback;

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
    private void Update()
    {
        // V�rifie si le joueur est dans la zone et appuie sur la touche d'interaction
        if (isInRange && playerInteraction != null && playerInteraction.CanInteract())
        {
            GiveItemToPlayer();
            AudioManager.instance.PlayClipAt(feedback, transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.gameObject.SetActive(true); // Affiche l’UI d’interaction
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.gameObject.SetActive(false); // Cache le texte d’interaction
        }
    }

    public void GiveItemToPlayer()
    {
        Debug.Log("Objet re�u !");
        Inventory.Instance.content.Add(item);
        Inventory.Instance.GetItem();
        if(DestroyGiver == true)
        {
            Destroy(gameObject);
        }
    }

}