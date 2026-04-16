using System.Data;
using UnityEngine;

// This class handles the trinket's ability to detect collisions and attach items to itself

public class S_Attach : MonoBehaviour
{
    private GameObject item;
    private bool temporaryConnection = false;
    public SO_GameData gameData;

    private void Start()
    {
        gameData.trinketInContactWithAnvil = false;
    }

    // When the item enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Remember the collided item and tell it that it's in the area
        item = collision.gameObject;
        item.SendMessage("Collided", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    // When the item leaves the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Remember the collided item and tell it that it's no longer in the area
        item = null;
        collision.SendMessage("LeftCollision", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    // When needing to attach the previously collided item
    void AttachItem()
    {
        // If the item exists, has a rigidbody, and isn't a hammer
        if (item != null && item.GetComponent<Rigidbody2D>() != null && !item.CompareTag("Hammer"))
        {
            // Create a fixed joint attaching the collided item to the trinket
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = item.GetComponent<Rigidbody2D>();

            // The item is now counted as being attached
            gameData.itemAttached = true;
            item.SendMessage("Attached", true);

            // Detach the item after 5 seconds of being attached
            Invoke("DetachItem", 5f);
            // Allow the connection to be destroyed
            temporaryConnection = true;
        }
    }

    // Remove the fixed joint from the trinket
    void DetachItem()
    {
        // If the item hasn't been permanently attached
        if (temporaryConnection)
        {
            // Destroy the fixed joint
            Destroy(GetComponent<FixedJoint2D>());
            // The item is no longer counted as being attached
            gameData.itemAttached = false;
            if (item != null)
            {
                item.SendMessage("Attached", false, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    // Forms a permanent bond between the item and trinket
    void StayTogether()
    {
        temporaryConnection = false;
        print("Stuck together");
        gameData.itemAttachedPermanently = true;
    }

    // Sent by S_Anvil
    void ContactWithAnvil(bool InContact)
    {
        gameData.trinketInContactWithAnvil = InContact;
    }
}
