using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ItemRowState
{
    CanBuy, 
    CanEquip, 
    Equipped,
}
public class ItemRowUI : MonoBehaviour
{
    private const string EQUIP_TEXT = "EQUIP";
    private const string EQUIPPED_TEXT = "EQUIPPED";

    [Header("UI References")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Button actionButton;
    [SerializeField] private TextMeshProUGUI actionText;

    private ItemData currentItem;

    public void SetUp(ItemData item, ItemRowState state, Action<ItemData> onClickCallback)
    {
        currentItem = item;
        iconImage.sprite = item.ItemSprite;
        nameText.text = item.ItemName;

        switch (state)
        {
            case ItemRowState.CanBuy:
                actionText.text = item.Price.ToString();
                actionButton.interactable = true;
                break;
            case ItemRowState.CanEquip:
                actionText.text = EQUIP_TEXT;
                actionButton.interactable = true;
                break;
            case ItemRowState.Equipped:
                actionText.text = EQUIPPED_TEXT;
                actionButton.interactable = false; // Đang mặc thì khóa nút
                break;
        }
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(() => onClickCallback?.Invoke(currentItem));
    }
}
