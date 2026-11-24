using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StoreTab
{
    Inventory,
    Shop,
}
public class StoreUI : MonoBehaviour
{
    [Header("Tab Buttons")]
    [SerializeField] private Button inventoryTabButton;
    [SerializeField] private Button shopTabButton;

    [Header("List Setup")]
    [SerializeField] private Transform contentContainer; 
    [SerializeField] private ItemRowUI itemRowPrefab;    
    
    private StoreTab currentTab;

    private void Awake()
    {
        //Event
        MenuUI.inventoryButtonClick += onShowInventory;
        MenuUI.outInventoryButtonClick += onHideInventory;
    }

    private void Start()
    {
        onHideInventory();
    }
    private void OnEnable()
    {
        // Đăng ký sự kiện khi mở bảng
        InventoryManager.OnInventoryUpdated += RefreshUI;

        inventoryTabButton.onClick.AddListener(() => SwitchTab(StoreTab.Inventory));
        shopTabButton.onClick.AddListener(() => SwitchTab(StoreTab.Shop));
        
        // Vẽ danh sách ngay khi vừa bật bảng]
        currentTab = StoreTab.Inventory;
        RefreshUI();
    }
    private void OnDisable()
    {
        // Hủy đăng ký sự kiện khi tắt bảng để tránh Memory Leak
        InventoryManager.OnInventoryUpdated -= RefreshUI;

        inventoryTabButton.onClick.RemoveAllListeners();
        shopTabButton.onClick.RemoveAllListeners();
    }

    private void SwitchTab(StoreTab newTab)
    {
        if (currentTab == newTab) return;
        
        currentTab = newTab;
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (InventoryManager.Instance == null) return;
        // 1. Xóa sạch các hàng cũ đang có trong Content
        foreach (Transform child in contentContainer)
        {
            Destroy(child.gameObject);
        }
        // 2. Lấy danh sách đồ tương ứng theo Tab đang chọn (IEnumerable chỉ đọc)
        IEnumerable<ItemData> itemsToDisplay = (currentTab == StoreTab.Inventory)
            ? InventoryManager.Instance.GetOwnedItems()
            : InventoryManager.Instance.GetShopItems();
        
        // 3. Sinh từng hàng mới lên giao diện
        foreach (ItemData item in itemsToDisplay)
        {
            ItemRowUI row = Instantiate(itemRowPrefab, contentContainer);

            if (currentTab == StoreTab.Inventory)
            {
                bool isEquipped = InventoryManager.Instance.IsEquipped(item);
                ItemRowState state = isEquipped ? ItemRowState.Equipped : ItemRowState.CanEquip;

                row.SetUp(item, state, HandleEquipClicked);
            }
            else
            {
                row.SetUp(item, ItemRowState.CanBuy, HandleBuyClicked);
            }
        }
    }

    private void HandleEquipClicked(ItemData item)
    {
        InventoryManager.Instance.EquipItem(item);
    }

    private void HandleBuyClicked(ItemData item)
    {
        // Hiện tại test mở khóa luôn; sau này sẽ thêm bước kiểm tra trừ Coin ở đây
        InventoryManager.Instance.UnlockItem(item);
    }
    private void onShowInventory()
    {
        gameObject.SetActive(true);
    }

    private void onHideInventory()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        MenuUI.inventoryButtonClick -= onShowInventory;
        MenuUI.outInventoryButtonClick -= onHideInventory;
    }
}

