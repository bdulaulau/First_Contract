using UnityEngine;
using UnityEngine.Events;

public class GiveItem : MonoBehaviour
{

    public bool isInRange;
    public Item item;
    public bool DestroyGiver;

    private Interaction playerInteraction;


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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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