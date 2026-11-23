using UnityEngine;

public enum ItemType
{
    BirdSkin,
    Background,
}
[CreateAssetMenu(fileName = "NewItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Basic Info")] 
    [SerializeField] private string itemID;
    [SerializeField] private string itemName;
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite itemSprite;

     [Header("Shop Info")] 
     [SerializeField] private int price;
     [SerializeField] private bool isUnlockedDefault;
     
     //Get
     public string ItemID => itemID;
     public string ItemName => itemName;
     public ItemType ItemType => itemType;
     public Sprite ItemSprite => itemSprite;
     public int Price => price;
     public bool IsUnlockedDefault => isUnlockedDefault;

}
