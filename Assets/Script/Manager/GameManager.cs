using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    // Khai báo điểm để lưu vào phần cứng
    private const string HIGHEST_SCORE_KEY = "HighestScore";
    
    // SCORE AND COIN
    private int score;
    private int highestScore;

    public int HighestScore
    {
        get => highestScore;
        private set => highestScore = value;
    }

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
        highestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY, 0); //Key và giá trị mặc định nếu không kiếm thấy
        
        //SetUp Event
        ScoreZone.OnScorePlus += AddScore;
        PlayerControl.OnBirdDied += GameOver;
        Coin.OnGetCoin += AddCoin;
        
        //EVENT BROADCAST
        OnChangeHighScore?.Invoke(highestScore);
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
            PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, highestScore);
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
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        ScoreZone.OnScorePlus -= AddScore;
        PlayerControl.OnBirdDied -= GameOver;
        Coin.OnGetCoin -= AddCoin;
    }
}
