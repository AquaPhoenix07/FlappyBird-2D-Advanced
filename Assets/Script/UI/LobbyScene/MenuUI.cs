using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    //BUTTON
    public Button playGameButton;
    public Button inventoryButton;
    //EVENT
    public static event Action playGameButtonClick;

    private void Awake()
    {
        playGameButton.onClick.AddListener(() => { playGameButtonClick?.Invoke();});
    }
    
    
    
}
