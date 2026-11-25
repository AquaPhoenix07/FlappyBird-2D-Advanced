using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";
    public static event Action OnLoadGameScene; 

    private void OnEnable()
    {
        MenuUI.playGameButtonClick += ChangeToGameScene;
    }

    private void ChangeToGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
        OnLoadGameScene?.Invoke();
    }

    private void OnDestroy()
    {
        MenuUI.playGameButtonClick -= ChangeToGameScene;
    }
}
