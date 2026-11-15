using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton; 
    public static event Action OnClickRestartButton;
    public static event Action OnClickMenuButton;

    private void Start()
    {
        restartButton.onClick.AddListener(HandleRestartButton);
        menuButton.onClick.AddListener(HandleMenuButton);
    }

    private void HandleRestartButton()
    {
        OnClickRestartButton?.Invoke();
    }

    private void HandleMenuButton()
    {
        OnClickMenuButton?.Invoke();
    }
    
}
