using System.Data;
using UnityEngine;

// This class handles the trinket's ability to detect collisions and attach items to itself

public class S_Attach : MonoBehaviour
{
    private GameObject item;
    public SO_GameData gameData;

    private void Start()
    {
        gameData.trinketInContactWithAnvil = false;
    }


    // When the item enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Remember the collided item and tell it that it's in the area
        if (collision.CompareTag("Modifier"))
        {
            item = collision.gameObject;
        }
        
        collision.SendMessage("Collided", gameObject, SendMessageOptions.DontRequireReceiver);
    }


    // When the item leaves the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the item isn
        if (collision.CompareTag("Modifier"))
        {
            item = null;
        }
        collision.SendMessage("LeftCollision", gameObject, SendMessageOptions.DontRequireReceiver);
    }


    // Forms a permanent bond between the item and trinket
    void StayTogether()
    {
        print("I got here." + item.name);
        // If the item exists, has a rigidbody, and isn't a hammer
        if (item != null && item.GetComponent<Rigidbody2D>() != null && !item.CompareTag("Hammer"))
        {
            // Create a fixed joint attaching the collided item to the trinket
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = item.GetComponent<Rigidbody2D>();

            // The item is now counted as being attached
            gameData.itemAttached = true;

            print("Stuck together");
            item.tag = "AttachedModifier";
        }
    }


    // Sent by S_Anvil
    void ContactWithAnvil(bool InContact)
    {
        gameData.trinketInContactWithAnvil = InContact;
    }
}
