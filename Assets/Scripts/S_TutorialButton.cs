using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_TutorialButton : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool visible = false;

    void Start()
    {
        // Hide the tutorial on start
        tutorialText.color = new Color(1f, 1f, 1f, 0f);
    }

    // A UnityEvent calls this from the button itself
    // Toggles between showing the tutorial and hiding it
    public void ShowTutorial()
    {
        if (!visible)
        {
            tutorialText.color = new Color(1f, 1f, 1f, 1f);
            visible = true;
        }
        else
        {
            tutorialText.color = new Color(1f, 1f, 1f, 0f);
            visible = false;
        }
    }
}
