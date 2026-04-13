using UnityEngine;

public class S_Item : MonoBehaviour
{
    public enum itemTypeEnum {Item1, Item2, Item3};
    public itemTypeEnum itemType;

    private SpriteRenderer _renderer;
    public Sprite[] sprites; 

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

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
}
