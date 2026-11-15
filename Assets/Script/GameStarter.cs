using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public static event Action OnGameStart;
    //Cờ trạng thái : False = chưa bắt đầu, true = đã bắt đầu
    private bool isStarted;

    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isStarted = false;
        Time.timeScale = 0f;
    }
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
        if (!isStarted && Input.GetKeyDown(KeyCode.Space))
        {
            isStarted = true;
            Time.timeScale = 1f;
            OnGameStart?.Invoke();
        }
    }
}
