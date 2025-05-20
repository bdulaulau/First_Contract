using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ObjectInteractionFusible : MonoBehaviour
{
    private bool _isActive;

    public Item item;
    private Interaction playerInteraction;
    public bool isInRange;
    public TextMeshProUGUI interactUI;
    public KeyDoorTrigger keyDoorTrigger;
    public bool OpenTheDoor = false;
    private bool Use = false;


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
        _isActive = !_isActive;

            if (_isActive)
            {
                Debug.Log("Activation avec la clé détectée");

                // Consomme l'objet (clé)
                Inventory.Instance.UseItem(item);
                Inventory.Instance.UpdateInventoryUI();
                OpenTheDoor = true;
                interactUI.gameObject.SetActive(false);
                Use = true;
                // Déclenche l'ouverture de porte si possible
                // KeyDoorTrigger doorTrigger = GetComponent<KeyDoorTrigger>();
                // if (doorTrigger != null)
                // {
                //     doorTrigger.TryUnlock();
                // 
            
                //  if (FusibleUIManager.Instance != null)
                // {
                //     FusibleUIManager.Instance.OpenUI();
                // }
        }
    }
    else
    {
        Debug.Log("La clé est manquante !");
    }
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Use == false)
            {
                isInRange = true;
                interactUI.gameObject.SetActive(true); // Affiche l’UI d’interaction
            }
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