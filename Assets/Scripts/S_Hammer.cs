using UnityEngine;

public class S_Hammer : MonoBehaviour
{
    // When hitting something with the hammer, make it do an event if it has one. Also pass in the speed of the collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("HammerHit", collision.relativeVelocity.magnitude, SendMessageOptions.DontRequireReceiver);
    }
}
