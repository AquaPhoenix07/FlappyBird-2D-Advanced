using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextMesh;
    public TextMeshProUGUI highestScoreTextMesh;
    public TextMeshProUGUI scoreTextBoard;
    public TextMeshProUGUI highestScoreTextBoard;
    public TextMeshProUGUI moneyText;
    public Canvas gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }
    private void Start()
    {
        GameManager.Instance.OnChangeScore += UpdateScore;
        GameManager.Instance.OnChangeHighScore += UpdateHighScore;
        PlayerControl.OnBirdDied += ShowGameOverCanvas;
        GameManager.Instance.OnChangeMoney += UpdateMoney;
    }
    private void Update()
    {
        
    }

    private void UpdateScore(int score)
    {
        scoreTextMesh.text = Convert.ToString(score);
        scoreTextBoard.text = Convert.ToString(score);
    }

    private void UpdateHighScore(int highestScore)
    {
        highestScoreTextMesh.text = Convert.ToString(highestScore);
        highestScoreTextBoard.text = Convert.ToString(highestScore);
    }

    private void UpdateMoney(int money)
    {
        moneyText.text = Convert.ToString(money);
    }

    private void ShowGameOverCanvas()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
        
}
