using System;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public static event Action OnScorePlus;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerControl>(out PlayerControl player))
        {
            OnScorePlus?.Invoke();
        }
    }
}
