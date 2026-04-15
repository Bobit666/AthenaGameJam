using TMPro;
using UnityEngine;

public class S_CoinCount : MonoBehaviour
{
    public SO_GameData gameData;
    private TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        gameData.coinCount = 0;
        coinText.text = "Coins: 0";
    }
    void IncrementCoins()
    {
        gameData.coinCount++;
        coinText.text = "Coins: " + gameData.coinCount;
    }
}
