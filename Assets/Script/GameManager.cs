using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    private int score;
    private int highestScore;
    public event Action<int> OnChangeScore;
    public event Action<int> OnChangeHighScore;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        highestScore = 0;
        ScoreZone.OnScorePlus += AddScore;
        PlayerControl.OnBirdDied += GameOver;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void AddScore()
    {
        score++;
        if (highestScore < score)
        {
            highestScore = score;
            OnChangeHighScore?.Invoke(highestScore);
        }
        OnChangeScore?.Invoke(score);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }
    
}
