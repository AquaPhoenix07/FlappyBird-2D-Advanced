using System;
using UnityEngine;

public enum AudioType{
    Jump,
    Score,
    ButtonClick,
    ButtonExit,
    GetCoin,
    GameOver,
}

[Serializable] public struct SoundEntry
{
    public AudioType type;
    public AudioClip clip;
}
[CreateAssetMenu(fileName = "SoundLibrarySO", menuName = "Scriptable Objects/SoundLibrarySO")]
public class SoundLibrarySO : ScriptableObject
{
    [SerializeField] private SoundEntry[] sounds;
    public SoundEntry[] Sounds => sounds;
}
