using UnityEngine;

public class KeyDoorTrigger : MonoBehaviour
{
    [Header("Objet requis pour ouvrir la porte")]
    [SerializeField] private Item requiredKey;

    [Header("Porte à ouvrir")]
    [SerializeField] private KeyDoor targetDoor;

    [Header("Interaction unique ?")]
    [SerializeField] private bool consumeKey = true;

    public bool OpenTheDoor = false;

    private bool alreadyUsed = false;

    public void TryUnlock()
    {
        if (alreadyUsed) return;

        if (Inventory.Instance != null && Inventory.Instance.content.Contains(requiredKey))
        {
            if (consumeKey)
            {
                Inventory.Instance.UseItem(requiredKey);
                Inventory.Instance.UpdateInventoryUI();
            }

            if (targetDoor != null)
                OpenTheDoor = true;

            alreadyUsed = true;

            Debug.Log("Clé utilisée, porte ouverte !");
        }
        else
        {
            Debug.Log("Clé manquante dans l'inventaire !");
        }
    }
}
