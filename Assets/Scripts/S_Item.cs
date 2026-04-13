using UnityEngine;

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
        _renderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

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
        }
    }

    void Collided(GameObject trinketOverlapped)
    {
        colliderObject = trinketOverlapped;
        inArea = true;
        print("Collided");
    }

    void LeftCollision(GameObject trinketOverlapped)
    {
        inArea = false;
        print("LeftCollision");
    }

    void CheckIfInArea()
    {
        if (inArea)
        {
            //body.gravityScale = 0;
            colliderObject.SendMessage("AttachItem");
        }
    }
}
