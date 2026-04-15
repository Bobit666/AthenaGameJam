using UnityEngine;

// This class handles the trinket's ability to detect collisions and attach items to itself

public class S_Attach : MonoBehaviour
{
    private GameObject item;

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
        if (item != null)
        {
            // Create a fixed joint attaching the collided item to the trinket
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = item.GetComponent<Rigidbody2D>();
        }
    }
}
