using UnityEngine;

public class S_Attach : MonoBehaviour
{
    private Collider2D _collider;
    private bool overlapping = false;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapping = true;
        print("Overlapping");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapping = false;
        print("Exit");
    }
}
