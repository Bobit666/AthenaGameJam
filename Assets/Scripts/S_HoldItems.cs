using UnityEngine;

// This class handles the player's ability to click and drag items on the "Moveable" layer

public class S_HoldItems : MonoBehaviour
{
    private bool dragging = false;
    private GameObject item;
    private Rigidbody2D body;
    private float moveForce = 70;

    private void Start()
    {
        moveForce = Screen.width / 19;
    }

    void Update()
    {
        // If the mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse's position
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, LayerMask.GetMask("Moveable"));

            // If the mouse hit anything from the moveable layer
            if (hit)
            {
                // Record the hit item and get its rigidbody
                item = hit.transform.gameObject;
                body = item.GetComponent<Rigidbody2D>();

                // You are now dragging
                dragging = true;
            }
        }

        // If the player lets go
        else if (Input.GetMouseButtonUp(0)) 
        {
            // You are no longer dragging
            dragging = false;

            // If they were holding an item before
            if (item != null) 
            {
                // Set all of the body's variables back to how they were before being picked up
                body.gravityScale = 1;
                body.linearDamping = 0;

                // Stop the body from getting flung too far
                body.linearVelocity = Vector3.ClampMagnitude(body.linearVelocity, 20);

                // Check if the item is overlapping a trinket
                item.SendMessage("CheckIfInArea", SendMessageOptions.DontRequireReceiver);
            }
        }

        // While the item is being dragged
        if (dragging)
        {
            // Remove the item's gravity so it doesn't fall
            body.gravityScale = 0;

            // Find the direction to move in
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - item.transform.position;

            // Add force in that direction
            body.AddForce(direction.normalized * moveForce);

            // If the item is close to the mouse 
            if (item.transform.position.x - mousePosition.x <= 5 || item.transform.position.y - mousePosition.y <= 7f)
            {
                // Damp its velocity to prevent it from getting flung back and forth
                body.linearDamping = 10;
            }
        }
    }
}
