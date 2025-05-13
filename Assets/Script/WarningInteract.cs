using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningInteract : MonoBehaviour
{

    public bool isInRange;
    public TextMeshProUGUI interactUI;
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
