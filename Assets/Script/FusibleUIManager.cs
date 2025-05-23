using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FusibleUIManager : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Image fusibleUI;
    [SerializeField] private Animator animatorFusible; 

    private bool isPlayerInZone = false;
    private bool isUIOpen = false;
    public KeyDoorTrigger keyDoorTrigger;
    public ObjectInteraction objectInteraction;
    public GameObject Feedback;
    private void Start()
    {
        if (fusibleUI != null)
        {
            fusibleUI.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            ToggleUI(true);
        }

        if (isUIOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUI(false);
        }

        // Déclenche le trigger avec la touche R par exemple
        if (isUIOpen && objectInteraction.OpenTheDoor == true)
        {
            TriggerRepair();
        }
    }

    private void ToggleUI(bool open)
    {
        if (fusibleUI != null)
        {
            fusibleUI.gameObject.SetActive(open);
            isUIOpen = open;
            Debug.Log(open ? "UI FUSIBLE OUVERTE" : "UI FUSIBLE FERMÉE");
        }
    }

    public void TriggerRepair()
    {
        if (animatorFusible != null)
        {
            animatorFusible.SetBool("Repair", true); ;
            StartCoroutine(WaitAndExecute());
            Debug.Log("Animation de réparation lancée !");
        }
        else
        {
            Debug.LogWarning("Animator non assigné !");
        }
    }

    private IEnumerator WaitAndExecute()
    {

        yield return new WaitForSeconds(1.2f);
        Feedback.gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            ToggleUI(false);
        }
    }
}
