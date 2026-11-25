using UnityEngine;

public class BackgroundVisual : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;

    private void Awake()
    {
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeBackgroundSkin();
    }

    private void ChangeBackgroundSkin()
    {
        if (InventoryManager.Instance == null) return;
        ItemData currentBackground = InventoryManager.Instance.GetCurrentBackground();
        backgroundSpriteRenderer.sprite = currentBackground.ItemSprite;
    }
}
