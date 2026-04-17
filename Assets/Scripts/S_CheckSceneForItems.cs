using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CheckSceneForItems : MonoBehaviour
{
    public SO_GameData gameData;

    private void Start()
    {
        gameData.modifiersInScene = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Modifier"))
        {
            gameData.modifiersInScene++;
        }
    }

    void ModifierRemoved()
    {
        gameData.modifiersInScene--;
        print(gameData.modifiersInScene);
        if (gameData.modifiersInScene == 0)
        {
            Invoke("EndGame", 2.0f);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
