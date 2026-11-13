using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextMesh;
    public TextMeshProUGUI highestScoreTextMesh;
    public TextMeshProUGUI scoreTextBoard;
    public TextMeshProUGUI highestScoreTextBoard;
    public TextMeshProUGUI coinText;
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
        GameManager.Instance.OnChangeCoin += UpdateCoin;
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

    private void UpdateCoin(int coin)
    {
        coinText.text = Convert.ToString(coin);
    }

    private void ShowGameOverCanvas()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnChangeScore -= UpdateScore;
        GameManager.Instance.OnChangeHighScore -= UpdateHighScore;
        PlayerControl.OnBirdDied -= ShowGameOverCanvas;
        GameManager.Instance.OnChangeCoin -= UpdateCoin;
    }
}
