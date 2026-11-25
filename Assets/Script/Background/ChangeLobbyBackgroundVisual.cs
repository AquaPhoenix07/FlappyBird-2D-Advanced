using UnityEngine;
using UnityEngine.UI;

public class ChangeLobbyBackgroundVIsual : MonoBehaviour
{
    private Image lobbyPanelImage;

    private void Awake()
    {
        lobbyPanelImage = GetComponent<Image>();
    }

    private void Start()
    {
        InventoryManager.OnInventoryUpdated += ChangeLobbyBackground;
    }

    private void ChangeLobbyBackground()
    {
        ItemData currentBackground = InventoryManager.Instance.GetCurrentBackground();
        lobbyPanelImage.sprite = currentBackground.ItemSprite;
    }

    private void OnDestroy()
    {
        InventoryManager.OnInventoryUpdated -= ChangeLobbyBackground;
    }
    
}
