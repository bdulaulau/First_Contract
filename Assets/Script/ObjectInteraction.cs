using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class ObjectInteraction : MonoBehaviour
{
    private bool _isActive;

    public Item item;
    private Interaction playerInteraction;
    public bool isInRange;
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
        // Vérifie si le joueur est dans la zone et appuie sur la touche d'interaction
        if (isInRange && playerInteraction != null && playerInteraction.CanInteract())
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (Inventory.Instance != null && Inventory.Instance.content.Contains(item))
        {
            _isActive = !_isActive; //On assigne la valeur oppos�e � isActivate

            if (_isActive) //Si l'object a eu une interaction avec le player, trigger le onactivate event
            {
                Debug.Log("ACTIVATIOOOOON");
                Inventory.Instance.UseItem(item);
                Inventory.Instance.UpdateInventoryUI();
            }

            else
            {
                Debug.Log("DESACTIVATIONTIONTION");
            }
        }
        else
        {
            Debug.Log("Cle manquante !");
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
}