using TMPro;
using UnityEngine;

public class S_SellArea : MonoBehaviour
{
    private GameObject trinketInArea;
    private GameObject attachedModifierInArea;
    private bool combinedItemInArea = false;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI dialogueBox;
    public SO_GameData gameData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trinket") && collision.GetComponent<FixedJoint2D>() != null)
        {
            trinketInArea = collision.gameObject;
            combinedItemInArea = true;
            print("Found combined item");
        }

        else if (collision.CompareTag("AttachedModifier"))
        {
            attachedModifierInArea = collision.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trinket") && collision.GetComponent<FixedJoint2D>() != null)
        {
            combinedItemInArea = false;
        }
    }


    void SellTrinket()
    {
        if (combinedItemInArea)
        {
            if (attachedModifierInArea.name == gameData.modifierNeeded)
            {
                coinCount.SendMessage("IncrementCoins");
                dialogueBox.text = "Exactly what I needed! Cheers";
            }
            else
            {
                dialogueBox.text = "This isn't what I needed, but I'll take it anyways";
            }

            Destroy(trinketInArea);
            Destroy(attachedModifierInArea);
            
        }
    }
}
