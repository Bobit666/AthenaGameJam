using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// This class handles the player's ability to click and drag items on the "Moveable" layer

public class S_HoldItems : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;
    private GameObject item;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // If the mouse is down, cast a ray to see where the mouse is 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, LayerMask.GetMask("Moveable"));
            if (hit)
            {
                item = hit.transform.gameObject;
                // If the object was hit, record its transform
                dragging = hit.transform;
                // Record the offset between its centre and the mouse
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            // Stop dragging if the mouse lifts
            dragging = null;

            if (item != null)
            {
                // Set velocity to zero in order to prevent falling speed building up while dragging
                item.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }
        }

        if (dragging != null)
        {
            // If dragging, set the object's new transform to the mouse position + offset
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
