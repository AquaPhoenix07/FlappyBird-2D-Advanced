using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Singleton
    public static InventoryManager Instance { get; private set; }
    
    // Set Up Key const cho PlayerPrefs 
    private const string EQUIPPED_BIRD_KEY = "Equipped_BirdSkin";
    private const string EQUIPPED_BG_KEY = "Equipped_Background";
    private const string UNLOCKED_PREFIX = "Unlocked_";

    [Header("Database")] 
    [SerializeField] private List<ItemData> allItems = new List<ItemData>();
    
    //Save current state for skin and Background
    private ItemData currentBirdSkin;
    private ItemData currentBackground;
    
    // Event notification for UI 
    public static event Action OnInventoryUpdated;

    private void Awake()
    {
        //Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadEquippedItems();
    }
    // --- PHẦN LỌC DỮ LIỆU AN TOÀN (IEnumerable + yield return) ---
    public IEnumerable<ItemData> GetOwnedItems()
    {
        foreach (ItemData item in allItems)
        {
            if (IsUnlocked(item))
            {
                yield return item;
            }
        }
    }

    public IEnumerable<ItemData> GetShopItems()
    {
        foreach (ItemData item in allItems)
        {
            if (!IsUnlocked(item))
            {
                yield return item;
            }
        }
    }
    // --- PHẦN KIỂM TRA TRẠNG THÁI ---
    public bool IsUnlocked(ItemData item)
    {
        if (item.IsUnlockedDefault) return true;
        return PlayerPrefs.GetInt(UNLOCKED_PREFIX + item.ItemID, 0) == 1;
    }

    public bool IsEquipped(ItemData item)
    {
        return item == currentBirdSkin || item == currentBackground;
    }
    // --- PHẦN THAO TÁC (MUA & TRANG BỊ) ---
    public void UnlockItem(ItemData item)
    {
        if (IsUnlocked(item)) return;
        PlayerPrefs.SetInt(UNLOCKED_PREFIX + item.ItemID, 1);
        PlayerPrefs.Save();

        OnInventoryUpdated?.Invoke();
    }

    public void EquipItem(ItemData item)
    {
        if (!IsUnlocked(item)) return;
        if (item.ItemType == ItemType.BirdSkin)
        {
            currentBirdSkin = item;
            PlayerPrefs.SetString(EQUIPPED_BIRD_KEY, item.ItemID);
        }
        else if (item.ItemType == ItemType.Background)
        {
            currentBackground = item;
            PlayerPrefs.SetString(EQUIPPED_BG_KEY, item.ItemID);
        }

        PlayerPrefs.Save();
        OnInventoryUpdated?.Invoke();
    }
    // --- PHẦN NẠP DỮ LIỆU & TRUY XUẤT CHO GAME SCENE ---
    private void LoadEquippedItems()
    {
        string savedBirdID = PlayerPrefs.GetString(EQUIPPED_BIRD_KEY, string.Empty);
        string savedBgID = PlayerPrefs.GetString(EQUIPPED_BG_KEY, string.Empty);

        foreach (ItemData item in allItems)
        {
            if (item.ItemType == ItemType.BirdSkin)
            {
                if (item.ItemID == savedBirdID || (currentBirdSkin == null && item.IsUnlockedDefault))
                    currentBirdSkin = item;
            }
            else if (item.ItemType == ItemType.Background)
            {
                if(item.ItemID == savedBgID || (currentBackground == null && item.IsUnlockedDefault))
                currentBackground = item;
            }
        }
    }
    public ItemData GetCurrentBirdSkin() => currentBirdSkin;
    public ItemData GetCurrentBackground() => currentBackground;

    
}
