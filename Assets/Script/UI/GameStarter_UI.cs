using UnityEngine;

public class GameStarter_UI : MonoBehaviour
{
    public Canvas gameStarterCanvas;
    private void Start()
    {
        GameStarter.OnGameStart += TurnOffGameStarterCanvas;
    }
    private void TurnOffGameStarterCanvas()
    {
        gameStarterCanvas.gameObject.SetActive(false);
    }
}
