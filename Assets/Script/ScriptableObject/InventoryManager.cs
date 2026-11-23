using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Bộ nhớ lưu trữ Item đang mặc hiện tại
    private ItemData currentBirdSkin;
    private ItemData currentBackground;
    // Event
    public static event Action<ItemData> OnBirdSkinEquipped;
    public static event Action<ItemData> OnBackgroundEquipped;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void EquipItem(ItemData item)
    {
        if (item.itemType == ItemType.BirdSkin)
        {
            currentBirdSkin = item;
            OnBirdSkinEquipped?.Invoke(item);
        }

        if (item.itemType == ItemType.Background)
        {
            currentBackground = item;
            OnBackgroundEquipped?.Invoke(item);
        }
    }
}
