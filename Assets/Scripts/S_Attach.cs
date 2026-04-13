using UnityEngine;

public class S_Attach : MonoBehaviour
{
    private GameObject item;
    private FixedJoint2D joint;

    private void Start()
    {
        joint = GetComponent<FixedJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.gameObject;
        item.SendMessage("Collided", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        item = collision.gameObject;
        item.SendMessage("LeftCollision", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    void AttachItem()
    {
        joint.connectedBody = item.GetComponent<Rigidbody2D>();
        print("eyyyyy I'm attaching over ere");
    }
}
