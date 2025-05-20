using UnityEngine;
using UnityEngine.UI;

public class FusibleUIController : MonoBehaviour
{
    [SerializeField] private Image fusibleUI;

    private bool isUIOpen = false;
    private bool isPlayerInZone = false;

    void Start()
    {
        if (fusibleUI != null)
            fusibleUI.enabled = false;
    }

    void Update()
    {
        if (isPlayerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenUI();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }
    }

    public void OpenUI()
    {
        if (isUIOpen) return;

        if (fusibleUI != null)
            fusibleUI.enabled = true;

        isUIOpen = true;
        Debug.Log("UI ouverte");
    }

    public void CloseUI()
    {
        if (!isUIOpen) return;

        if (fusibleUI != null)
            fusibleUI.enabled = false;

        isUIOpen = false;
        Debug.Log("UI fermée");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInZone = true;
            Debug.Log("Joueur entré dans la zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInZone = false;
            Debug.Log("Joueur sorti de la zone");
            CloseUI();
        }
    }
}