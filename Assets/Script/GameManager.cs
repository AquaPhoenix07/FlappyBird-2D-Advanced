using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    private int score;
    private int highestScore;
    public static event
    
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
        score = 0;
        highestScore = 0;
        ScoreZone.OnScorePlus += AddScore;
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
        }
        
    }
    
}
