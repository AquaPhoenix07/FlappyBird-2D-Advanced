using UnityEngine;

public class GameStarter_UI : MonoBehaviour
{
    private void Start()
    {
        GameStarter.OnGameStart += TurnOffGameStarterCanvas;
    }
    private void TurnOffGameStarterCanvas()
    {
        this.gameObject.SetActive(false);
    }
}
