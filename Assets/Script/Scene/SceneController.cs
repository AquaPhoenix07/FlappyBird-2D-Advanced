using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";

    private void OnEnable()
    {
        MenuUI.playGameButtonClick += ChangeToGameScene;
    }

    private void ChangeToGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    private void OnDestroy()
    {
        MenuUI.playGameButtonClick -= ChangeToGameScene;
    }
}
