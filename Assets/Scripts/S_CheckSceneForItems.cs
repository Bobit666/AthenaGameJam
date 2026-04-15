using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CheckSceneForItems : MonoBehaviour
{ 
    private int modifierItemsInScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Modifier"))
        {
            modifierItemsInScene++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Modifier"))
        {
            modifierItemsInScene--;
            if (modifierItemsInScene == 0)
            {
                Invoke("EndGame", 1.0f);
            }
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
