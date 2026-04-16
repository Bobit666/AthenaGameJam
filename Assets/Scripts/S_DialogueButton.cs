using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_DialogueButton : MonoBehaviour
{
    private Button talkButton;
    public TextMeshProUGUI textBox;
    public RawImage dialogueBox;
    public SO_GameData gameData;
    public GameObject customerPrefab;
    private GameObject newCustomer;
    public TextMeshProUGUI buttonText;

    private Color visibleColour = new Color(1f, 1f, 1f, 1f);
    private Color invisibleColour = new Color(1f, 1f, 1f, 0f);

    public GameObject sellArea;
    private bool hasTalked = false;
    private bool customerThere = false;

    void Start()
    {
        // Tie the button being clicked to its own event
        talkButton = GetComponent<Button>();
        talkButton.onClick.AddListener(CreateDialogue);
        dialogueBox.color = invisibleColour;
    }

    // Progresses the interaction with the customer
    void CreateDialogue()
    {
        // If there isn't a custoer present, spawn a new one
        if (!customerThere)
        {
            newCustomer = Instantiate(customerPrefab);
            buttonText.text = "Talk";
            customerThere = true;
        }
        // If there is a customer and they haven't spoken yet
        else if (!hasTalked)
        {
            dialogueBox.color = visibleColour;
            // Set text depending on the modifier they ask for
            switch (gameData.modifierNeeded)
            {
                case "magnet":
                    textBox.text = "My " + gameData.trinketGiven + " needs to stick to my fridge! Any ideas?";
                    break;

                case "microwave":
                    textBox.text = "My " + gameData.trinketGiven + " isn't as hot as it used to be. Can you help with this?";
                    break;

                case "fan":
                    textBox.text = "I feel like my " + gameData.trinketGiven + " could stand to be a bit cooler. What can you do?";
                    break;

                case "thruster":
                    textBox.text = "You know what would be sick? If my " + gameData.trinketGiven + " could fly.";
                    break;

                default:
                    break;
            }

            // Tell the customer to spawn the item they talked about
            newCustomer.SendMessage("SpawnItem");
            buttonText.text = "Give";
            hasTalked = true;
        }

        // Turn the dialogue button into the sell button
        else
        {
            sellArea.SendMessage("SellTrinket");
        }
    }

    // Called by S_SellArea to empty the dialogue box after the customer leaves. It is delayed to give the player time to read
    void EmptyDialogueDelayed()
    {
        Invoke("EmptyDialogue", 2f);
        buttonText.text = "";
    }

    // Empties the dialogue box and resets the interaction so it can start again without issue
    void EmptyDialogue()
    {
        textBox.text = "";
        dialogueBox.color = invisibleColour;
        buttonText.text = "Next!";
        customerThere = false;
        hasTalked = false;
    }
}
