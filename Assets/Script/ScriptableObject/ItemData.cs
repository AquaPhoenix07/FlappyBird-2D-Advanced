using UnityEngine;

public enum ItemType
{
    BirdSkin,
    Background,
}
[CreateAssetMenu(fileName = "NewItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public string itemID;
    public ItemType itemType;
    public Sprite itemSprite;
    public bool isUnlockedDafault;
}
