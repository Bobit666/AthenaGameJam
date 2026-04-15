using UnityEngine;

public class S_ExitGame : MonoBehaviour
{
    // A UnityEvent calls this from the button itself
    public void EndGame()
    {
        Application.Quit();
    }
}
