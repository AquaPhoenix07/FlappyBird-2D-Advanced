using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextMesh;
    public TextMeshProUGUI highestScoreTextMesh;

    private void Start()
    {
        GameManager.Instance.OnChangeScore += UpdateScore;
        GameManager.Instance.OnChangeHighScore += UpdateHighScore;
    }
    private void Update()
    {
        
    }

    private void UpdateScore(int score)
    {
        scoreTextMesh.text = Convert.ToString(score);
    }

    private void UpdateHighScore(int highScore)
    {
        highestScoreTextMesh.text = Convert.ToString(highScore);
    }
        
}
