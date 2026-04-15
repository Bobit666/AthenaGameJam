using UnityEngine;

public class S_Anvil : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("ContactWithAnvil", true, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("ContactWithAnvil", false, SendMessageOptions.DontRequireReceiver);
    }
}
