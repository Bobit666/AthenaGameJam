using TMPro;
using UnityEngine;

// This class handles the coin count and how it is displayed

public class S_CoinCount : MonoBehaviour
{
    public SO_GameData gameData;
    private TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        // Set the coin count in the ScriptableObject to 0 when a new game starts
        gameData.coinCount = 0;
        coinText.text = "Coins: 0";
    }

    // Gives the player 1 coin and updates the display
    void IncrementCoins()
    {
        gameData.coinCount++;
        coinText.text = "Coins: " + gameData.coinCount;
    }
}
