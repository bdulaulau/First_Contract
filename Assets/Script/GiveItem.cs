using TMPro;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public bool isInRange;
    public Item item;
    public bool DestroyGiver;
    public AudioClip feedback;

    private Interaction playerInteraction;
    public TextMeshProUGUI interactUI;

    [Header("Objets à activer/désactiver")]
    public GameObject objectToDisable;
    public GameObject objectToEnable;

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

    public void GiveItemToPlayer()
    {
        Debug.Log("Objet reçu !");
        Inventory.Instance.content.Add(item);
        Inventory.Instance.GetItem();

        // Désactivation / activation
        if (objectToDisable != null)
            objectToDisable.SetActive(false);
        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        if (DestroyGiver)
        {
            Destroy(gameObject);
        }
    }
}
