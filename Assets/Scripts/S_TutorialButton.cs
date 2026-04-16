using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_TutorialButton : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public RawImage tutorialBox;
    private bool visible = false;

    private Color visibleColour = new Color(1f, 1f, 1f, 1f);
    private Color invisibleColour = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        // Hide the tutorial on start
        tutorialText.color = invisibleColour;
        tutorialBox.color = invisibleColour;
    }

    // A UnityEvent calls this from the button itself
    // Toggles between showing the tutorial and hiding it
    public void ShowTutorial()
    {
        if (!visible)
        {
            tutorialText.color = visibleColour;
            tutorialBox.color = visibleColour;
            visible = true;
        }
        else
        {
            tutorialText.color = invisibleColour;
            tutorialBox.color = invisibleColour;
            visible = false;
        }
    }
}
