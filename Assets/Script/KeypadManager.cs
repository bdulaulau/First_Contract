using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour
{

    public Image KeypadUI;
    public bool isInRange;
    private Interaction playerInteraction;
    public TextMeshProUGUI interactUI;

    [SerializeField] private DigitalDisplay display;

    [SerializeField] public string code;
    void Awake()
    {
        KeypadUI.gameObject.SetActive(false); // On désactive l’UI du clavier au lancement
    }

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInteraction = player.GetComponent<Interaction>(); // On récupère son script d’interaction
        }
        if (display != null)
        {
            display.SetKeypad(this); // on envoie le keypad au display
        }
    }

    public string GetCode()
    {
        return code;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
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
        if (KeypadUI.gameObject == true)
        {
            KeypadUI.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if(isInRange && playerInteraction != null && playerInteraction.CanInteract())
        {
            KeypadUI.gameObject.SetActive(true);
        }        
    }

}
