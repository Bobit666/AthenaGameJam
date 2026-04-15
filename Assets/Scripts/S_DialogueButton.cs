using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_DialogueButton : MonoBehaviour
{
    private Button talkButton;
    public TextMeshProUGUI textBox;
    public SO_GameData gameData;
    public GameObject customer;
    public TextMeshProUGUI buttonText;

    public GameObject sellArea;
    private bool hasTalked = false;

    void Start()
    {
        talkButton = GetComponent<Button>();
        talkButton.onClick.AddListener(CreateDialogue);
    }

    void CreateDialogue()
    {
        if (!hasTalked)
        {
            switch (gameData.modifierNeeded)
            {
                case "magnet":
                    textBox.text = "My " + gameData.trinketGiven + " needs to stick to my fridge! Any ideas?";
                    break;

                case "microwave":
                    textBox.text = "My " + gameData.trinketGiven + " isn't as hot as it used to be. Can you help with this?";
                    break;

                default:
                    break;
            }

            customer.SendMessage("SpawnItem");
            buttonText.text = "Give";
            hasTalked = true;
        }

        else
        {
            sellArea.SendMessage("SellTrinket");
        }
    }
}
