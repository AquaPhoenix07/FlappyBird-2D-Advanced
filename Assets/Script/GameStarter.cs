using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static event Action OnGameStart;
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Update()
    {
        StartGame();
    } 
    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            OnGameStart?.Invoke();
            this.enabled = false;
        }
    }
}
