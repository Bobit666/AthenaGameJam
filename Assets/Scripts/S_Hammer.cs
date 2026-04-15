using UnityEngine;

public class S_Hammer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("HammerHit", collision.relativeVelocity.magnitude, SendMessageOptions.DontRequireReceiver);
    }
}
