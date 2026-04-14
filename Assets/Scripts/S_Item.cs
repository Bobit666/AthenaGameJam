using UnityEngine;

// This class handles the item prefab's collision and sprite (an enumerator decides its sprite)

public class S_Item : MonoBehaviour
{
    public string itemName;
    private bool inArea = false;
    private GameObject colliderObject;

    // Called by the trinket once it overlaps the trigger
    void Collided(GameObject trinketOverlapped)
    {
        // Remember the trinket that it is overlapping
        colliderObject = trinketOverlapped;

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
            colliderObject.SendMessage("AttachItem");
        }
    }
}
