using TMPro;
using UnityEngine;

// This class handles the shopfront area, detecting items within itself and selling trinkets. 

public class S_SellArea : MonoBehaviour
{
    private GameObject trinketInArea;
    private GameObject attachedModifierInArea;
    private bool combinedItemInArea = false;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI dialogueBox;
    public GameObject dialogueButton;
    public SO_GameData gameData;

    private GameObject customer;

    // When an item enters the shopfont area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If they are a trinket with something attached (a modifier item), get a reference of it
        if (collision.CompareTag("Trinket") && collision.GetComponent<FixedJoint2D>() != null)
        {
            trinketInArea = collision.gameObject;
            combinedItemInArea = true;
            print("Found combined item");
        }

        // Get a reference to the modifier attached to the trinket
        else if (collision.CompareTag("AttachedModifier"))
        {
            attachedModifierInArea = collision.gameObject;
        }
    }

    // If the trinket leaves the shopfront
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trinket") && collision.GetComponent<FixedJoint2D>() != null)
        {
            combinedItemInArea = false;
        }
    }


    // Called by S_DialogueButton after the customer has given you their trinket and you have clicked the button to sell
    void SellTrinket()
    {
        // If the completed item is in the selling area
        if (combinedItemInArea)
        {
            // If the correct modifier has been applied
            if (attachedModifierInArea.name == gameData.modifierNeeded)
            {
                // Increase coin count and give feedback via dialogue
                coinCount.SendMessage("IncrementCoins");
                dialogueBox.text = "Exactly what I needed! Cheers";
            }
            // If the incorrect modifier has been applied
            else
            {
                // Give feedback via dialogue
                dialogueBox.text = "This isn't what I needed, but I'll take it anyways";
            }

            // Take the trinket and modifier away
            Destroy(trinketInArea);
            Destroy(attachedModifierInArea);

            // Tell the customer to disappear
            customer = GameObject.Find("Customer(Clone)");
            customer.SendMessage("Disappear");

            // Empty the dialogue box
            dialogueButton.SendMessage("EmptyDialogueDelayed");
        }
    }
}
