using TMPro;
using UnityEngine;

public class CoinDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinOnText;

    private void Start()
    {
        ChangeCoinOnText(CoinManager.Instance.TotalCoin);
        CoinManager.OnTotalCoinChange += ChangeCoinOnText;
    }

    private void ChangeCoinOnText(int coin)
    {
        coinText.text = coin.ToString();
    }

    private void OnDestroy()
    {
        CoinManager.OnTotalCoinChange -= ChangeCoinOnText;
    }
}
