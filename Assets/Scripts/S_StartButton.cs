using UnityEngine;
using UnityEngine.SceneManagement;

public class S_StartButton : MonoBehaviour
{
    // A UnityEvent calls this from the button itself
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
