using UnityEngine;

public class BirdVisual : MonoBehaviour
{
    private Animator birdAnimator;
    private SpriteRenderer birdSprite;
    

    private void Awake()
    {
        birdAnimator = GetComponent<Animator>();
        birdSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        if (InventoryManager.Instance == null) return;
        
        ItemData currentBirdSkin = InventoryManager.Instance.GetCurrentBirdSkin();
        
        if (currentBirdSkin == null) return;

        if (currentBirdSkin.ItemSprite != null)
        {
            birdSprite.sprite = currentBirdSkin.ItemSprite;
        }

        if (currentBirdSkin.AnimatorController != null)
        {
            birdAnimator.runtimeAnimatorController = currentBirdSkin.AnimatorController;
        }
    }
}
