using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{

    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public TextMeshProUGUI itemNameUI;
    public Sprite emptyItemImage;

    public static Inventory Instance;

    public GameObject InventoryUI;
    public Image ItemDisplayUI;
    public Image SpriteDisplay;
    public TextMeshProUGUI Description;
    public int newItem = 0;
    public UseInventory useInventory;

    private Animator animator;

    private void Awake()
    {
        animator = InventoryUI.GetComponent<Animator>();
        animator.SetBool("IsOpen", false); //cache l'inventaire au départ
        if (Instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Inventory dans la sc�ne");
            return;
        }
        Instance = this;
        InventoryUI.gameObject.SetActive(false);
        ItemDisplayUI.gameObject.SetActive(false);
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    private void Update()
    {
        if (useInventory != null)
        {
            if (useInventory.InvStatue == false)
            {
                CloseInventory();
            }
            if (useInventory.InvStatue == true)
            {
                OpenInventory();
            }
        }
    }

    private void CloseInventory()
    {
       animator.SetBool("IsOpen", false); 
    }

    private void OpenInventory()
    {
        InventoryUI.gameObject.SetActive(true);
        animator.SetBool("IsOpen", true);
    }

    public void GetItem()
    {
        ItemDisplayUI.gameObject.SetActive(true);

        if (content.Count > 0) 
        {
            newItem = content.Count - 1;
        }

        SpriteDisplay.sprite = content[newItem].image;
        Description.text = content[newItem].description;

        GetNextItem();
        UpdateInventoryUI();
    }

    public void SeeDescription()
    {
        ItemDisplayUI.gameObject.SetActive(true);
        SpriteDisplay.sprite = content[contentCurrentIndex].image;
        Description.text = content[contentCurrentIndex].description;

    }

    public void UseItem(Item item)
    {
        // Ajuste l'index pour �viter une erreur d'acc�s hors limites
        if (content.Count == 0)
        {
            contentCurrentIndex = 0; // R�initialise si l'inventaire est vide
        }
        else if (contentCurrentIndex >= content.Count)
        {
            contentCurrentIndex = content.Count - 1; // Ajuste l'index pour rester valide
        }
        content.Remove(item);
        UpdateInventoryUI();
    }

    public void CloseDisplayUI()
    {
        ItemDisplayUI.gameObject.SetActive(false);
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count -1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }


    public void UpdateInventoryUI()
    {
        if(content.Count > 0 && contentCurrentIndex < content.Count)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }
}
