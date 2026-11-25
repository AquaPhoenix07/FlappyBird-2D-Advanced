using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    
    private int totalCoin ;
    public static event Action<int> OnTotalCoinChange;
    private const string TOTAL_COIN_KEY = "totalCoinKey";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        totalCoin = PlayerPrefs.GetInt(TOTAL_COIN_KEY, 0);
    }

    private void Start()
    {
        Coin.OnGetCoin += ChangeTotalCoin;
    }

    private void ChangeTotalCoin()
    {
        totalCoin++;
        PlayerPrefs.SetInt(TOTAL_COIN_KEY, totalCoin);
        OnTotalCoinChange?.Invoke(totalCoin);
    }

    public bool TrySpendCoin(int coin)
    {
        if (coin <= totalCoin)
        {
            totalCoin -= coin;
            PlayerPrefs.SetInt(TOTAL_COIN_KEY, totalCoin);
            OnTotalCoinChange?.Invoke(totalCoin);
            return true;
        }

        return false;
    }

    public int TotalCoin => totalCoin;

    private void OnDestroy()
    {
        Coin.OnGetCoin -= ChangeTotalCoin;
    }
}
