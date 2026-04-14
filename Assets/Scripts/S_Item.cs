using UnityEngine;

// This class handles the item prefab's collision and sprite (an enumerator decides its sprite)

public class S_Item : MonoBehaviour
{
    public enum itemTypeEnum {Item1, Item2, Item3};
    public itemTypeEnum itemType;

    private SpriteRenderer _renderer;
    public Sprite[] sprites;

    private bool inArea = false;
    private GameObject colliderObject;
    private Rigidbody2D body;

    private void Start()
    {
        // Get components
        _renderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        // Switch on the item type enum to determine the sprite to use
        switch (itemType)
        {
            case itemTypeEnum.Item1:
                _renderer.sprite = sprites[0];
                break;

            case itemTypeEnum.Item2:
                _renderer.sprite = sprites[1];
                break;

            case itemTypeEnum.Item3:
                _renderer.sprite = sprites[2];
                break;
            default:
                break;
        }
    }

    // Called by the trinket once it overlaps the trigger
    void Collided(GameObject trinketOverlapped)
    {
        // Remember the trinket that it is overlapping
        colliderObject = trinketOverlapped;

        // You are now in the area to attach to
        inArea = true;
    }

    // Called by the trinket once it leaves the trigger
    void LeftCollision(GameObject trinketOverlapped)
    {
        // No longer in area to attach to
        inArea = false;
    }

    // Called by S_HoldItem when the item is dropped
    void CheckIfInArea()
    {
        // If the item is within the trinket's trigger
        if (inArea)
        {
            // Ask the trinket politely if it can get attached
            colliderObject.SendMessage("AttachItem");
        }
    }
}
