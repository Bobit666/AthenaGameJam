using UnityEngine;

// This class handles the item prefab's collision and sprite (an enumerator decides its sprite)

public class S_Item : MonoBehaviour
{
    private bool inArea = false;
    private GameObject trinketToAttachTo;
    private bool inContactWithAnvil;
    private int tinkCount;
    public SO_GameData gameData;

    private void Start()
    {
        gameData.itemAttached = false;
        gameData.itemAttachedPermanently = false;
    }

    // Called by the trinket once it overlaps the trigger
    void Collided(GameObject trinketOverlapped)
    {
        // Remember the trinket that it is overlapping
        trinketToAttachTo = trinketOverlapped;

        // You are now in the area to attach to
        inArea = true;
    }

    // Called by the trinket once it leaves the trigger
    void LeftCollision(GameObject trinketOverlapped)
    {
        // No longer in area to attach to
        inArea = false;
    }

    // Called by S_HoldItem when the item is dropped
    void CheckIfInArea()
    {
        // If the item is within the trinket's trigger
        if (inArea)
        {
            // Ask the trinket politely if it can get attached
            trinketToAttachTo.SendMessage("AttachItem");
            gameObject.tag = "AttachedModifier";
        }
    }

    void ContactWithAnvil(bool InContact)
    {
        inContactWithAnvil = InContact;
    }

    void HammerHit(float hitStrength)
    {
        print(tinkCount);
        if (gameData.itemAttached && inContactWithAnvil || gameData.trinketInContactWithAnvil)
        {
            if (hitStrength < 8 && hitStrength > 3)
            {
                print("Tink");
                tinkCount++;
            }
            else if (hitStrength > 8)
            {
                print("Clank");
                tinkCount--;
            }
        }

        if (tinkCount == 5)
        {
            trinketToAttachTo.SendMessage("StayTogether");
        }
    }
}
