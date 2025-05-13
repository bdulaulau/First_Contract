using UnityEngine;

public class ObjectKeyDoor : MonoBehaviour
{
    [Header("Clé requise")]
    [SerializeField] private Item requiredKey;

    [Header("Porte à ouvrir")]
    [SerializeField] private Door door;

    [Header("Interaction optionnelle à désactiver après usage")]
    [SerializeField] private ObjectInteraction interaction;

    private bool isUsed = false;

    public void TryOpenDoor()
    {
        if (isUsed) return;

        if (Inventory.Instance != null && Inventory.Instance.content.Contains(requiredKey))
        {
            Inventory.Instance.UseItem(requiredKey);
            Inventory.Instance.UpdateInventoryUI();

            if (door != null)
                door.OpenDoor();

            if (interaction != null)
                interaction.enabled = false;

            isUsed = true;

            Debug.Log("Porte ouverte avec la clé.");
        }
        else
        {
            Debug.Log("La clé requise n’est pas dans l’inventaire !");
        }
    }
}