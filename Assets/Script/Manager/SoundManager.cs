using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private SoundLibrarySO soundLibrary;
    private Dictionary<AudioType, AudioClip> soundDictionary;

    private AudioSource sfxSource;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        sfxSource = GetComponent<AudioSource>();
        InputSoundLibrary();
    }

    private void Start()
    {
        Coin.OnGetCoin += HandleGetCoinSound;
        ScoreZone.OnScorePlus += HandleScoreSound;
        PlayerControl.OnBirdDied += HandleGameOverSound;
        PlayerControl.OnBirdJump += HandleJumpSound;
        MenuUI.playGameButtonClick += HandleButtonClickSound;
        MenuUI.inventoryButtonClick += HandleButtonClickSound;
        MenuUI.outInventoryButtonClick += HandleButtonClickSound;
        GameOver_UI.OnClickMenuButton += HandleButtonExitSound;
        GameOver_UI.OnClickRestartButton += HandleButtonClickSound;
    }

    private void InputSoundLibrary()
    {
        soundDictionary = new Dictionary<AudioType, AudioClip>();
        foreach (SoundEntry soundEntry in soundLibrary.Sounds)
        {
            if (soundEntry.clip != null)
            {
                soundDictionary.Add(soundEntry.type, soundEntry.clip);
            }
        }
    }

    private void PlaySFX(AudioType type)
    {
        float volumeScale = 1f;
        if (soundDictionary.TryGetValue(type, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip, volumeScale);
        }
    }

    private void HandleGetCoinSound()
    {
        PlaySFX(AudioType.GetCoin);
    }

    private void HandleScoreSound()
    {
        PlaySFX(AudioType.Score);
    }

    private void HandleJumpSound()
    {
        PlaySFX(AudioType.Jump);
    }

    private void HandleButtonClickSound()
    {
        PlaySFX(AudioType.ButtonClick);
    }

    private void HandleButtonExitSound()
    {
        PlaySFX(AudioType.ButtonExit);
    }

    private void HandleGameOverSound()
    {
        PlaySFX(AudioType.GameOver);
    }

    private void OnDestroy()
    {
        Coin.OnGetCoin -= HandleGetCoinSound;
        ScoreZone.OnScorePlus -= HandleScoreSound;
        PlayerControl.OnBirdDied -= HandleGameOverSound;
        PlayerControl.OnBirdJump -= HandleJumpSound;
        MenuUI.playGameButtonClick -= HandleButtonClickSound;
        MenuUI.inventoryButtonClick -= HandleButtonClickSound;
        MenuUI.outInventoryButtonClick -= HandleButtonClickSound;
        GameOver_UI.OnClickMenuButton -= HandleButtonExitSound;
        GameOver_UI.OnClickRestartButton -= HandleButtonClickSound;
    }
}
