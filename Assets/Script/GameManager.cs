using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    
    // SCORE AND COIN
    private int score;
    private int highestScore;
    private int coin;
    // EVENTS
    public event Action<int> OnChangeScore;
    public event Action<int> OnChangeHighScore;
    public event Action<int> OnChangeCoin;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
        Coin.OnGetCoin += AddCoin;
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

    private void AddCoin()
    {
            coin++;
            OnChangeCoin?.Invoke(coin);
    }
    private void GameOver()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        ScoreZone.OnScorePlus -= AddScore;
        PlayerControl.OnBirdDied -= GameOver;
        Coin.OnGetCoin -= AddCoin;
    }
}
