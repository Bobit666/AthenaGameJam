using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_StartButton : MonoBehaviour
{
    private Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(startGame);
    }

    void startGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
