using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id; //identifiant unique pour l'objet
    public string Name;
    public string description;
    public Sprite image; //image dans l'inventaire
}

