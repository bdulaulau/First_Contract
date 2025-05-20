using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KeyDoorTrigger : MonoBehaviour
{
    [Header("Objet requis pour ouvrir la porte")]
    [SerializeField] private Item requiredKey;

    [Header("Porte à ouvrir")]
    [SerializeField] private KeyDoor targetDoor;

    [Header("Interaction unique ?")]
    [SerializeField] private bool consumeKey = true;


    [SerializeField] private Image fusibleUI;
    [SerializeField] private Animator animatorFusible; 

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
                StartCoroutine(WaitAndExecute());
            }

            if (targetDoor != null)
                OpenTheDoor = true;

            alreadyUsed = true;
        }
    }
    private IEnumerator WaitAndExecute()
    {
        // Attendre 1 seconde
        yield return new WaitForSeconds(1.5f);
        TriggerRepair();
    }

        public void TriggerRepair()
    {
        if (animatorFusible != null)
        {
            animatorFusible.SetBool("Repair", true); ;
            Debug.Log("Animation de réparation lancée !");
        }
        else
        {
            Debug.LogWarning("Animator non assigné !");
        }
    }
}
