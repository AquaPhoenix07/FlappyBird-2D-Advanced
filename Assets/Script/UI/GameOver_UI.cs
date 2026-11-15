using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    public Button restartButton;
    public static event Action OnClickRestartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(HandleRestartButton);
    }

    private void HandleRestartButton()
    {
        OnClickRestartButton?.Invoke();
    }
}
