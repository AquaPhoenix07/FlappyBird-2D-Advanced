using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnGetCoin;
    public event Action<GameObject> OnCoinReturn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerControl>(out _))
        {
            OnGetCoin?.Invoke();
            OnCoinReturn?.Invoke(gameObject);
        }
    }
}
