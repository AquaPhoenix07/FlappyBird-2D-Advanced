using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    // Khai báo điểm để lưu vào phần cứng
    private const string HIGHEST_SCORE_KEY = "HighestScore";
    private const string MENU_LEVEL = "Lobby";
    
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
        score = 0;
        highestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY, 0); //Key và giá trị mặc định nếu không kiếm thấy
        
        
        //SetUp Event
        ScoreZone.OnScorePlus += AddScore;
        PlayerControl.OnBirdDied += GameOver;
        Coin.OnGetCoin += AddCoin;
        GameOver_UI.OnClickRestartButton += RestartLevel;
        GameOver_UI.OnClickMenuButton += BackToMenu;
        SceneController.OnLoadGameScene += ResetScore;
        
        //EVENT BROADCAST
        OnChangeHighScore?.Invoke(highestScore);
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

    private void RestartLevel()
    {
        Debug.Log("Restart");
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(MENU_LEVEL);
    }
    private void OnDestroy()
    {
        ScoreZone.OnScorePlus -= AddScore;
        PlayerControl.OnBirdDied -= GameOver;
        Coin.OnGetCoin -= AddCoin;
        GameOver_UI.OnClickRestartButton -= RestartLevel;
        GameOver_UI.OnClickMenuButton -= BackToMenu;
        SceneController.OnLoadGameScene -= ResetScore;
    }

    private void ResetScore()
    {
        score = 0;
        coin = 0;
    }
}
