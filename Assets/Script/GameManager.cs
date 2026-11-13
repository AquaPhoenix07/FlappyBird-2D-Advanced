using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    private int score;
    private int highestScore;
    private static int money;
    public event Action<int> OnChangeScore;
    public event Action<int> OnChangeHighScore;
    public event Action<int> OnChangeMoney;
    
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
        
        //SetUp Event
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
        if (score % 5 == 0 && score != 0)
        {
            money++;
            OnChangeMoney?.Invoke(money);
        }
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
