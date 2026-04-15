using UnityEngine;

public class S_Anvil : MonoBehaviour
{
    // When something collides with the anvil, tell it to do an event if it can
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("ContactWithAnvil", true, SendMessageOptions.DontRequireReceiver);
    }

    // When something gets off the anvil, tell it to do an event if it can
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("ContactWithAnvil", false, SendMessageOptions.DontRequireReceiver);
    }
}
