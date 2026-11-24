using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    //BUTTON
    public Button playGameButton;
    public Button inventoryButton;

    public Button outInventoryButton;
    //EVENT
    public static event Action playGameButtonClick;
    public static event Action inventoryButtonClick;
    public static event Action outInventoryButtonClick;

    private void Awake()
    {
        playGameButton.onClick.AddListener(() => { playGameButtonClick?.Invoke();});
        inventoryButton.onClick.AddListener(() => { inventoryButtonClick?.Invoke(); });
        outInventoryButton.onClick.AddListener(() => { outInventoryButtonClick?.Invoke(); });
    }
    
    
    
}
