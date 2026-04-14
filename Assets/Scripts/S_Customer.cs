using UnityEngine;
using TMPro;

public class S_Customer : MonoBehaviour
{
    public GameObject[] trinketPrefab;
    private int itemToSpawn;
    private int modifierToNeed;
    public GameObject dialogueBox;
    private Vector3 spawnLocation = new Vector3(-20f, 0f, 0f);

    public GameObject dialogueButton;
    public SO_GameData gameData;

    private bool spawnedItem = false;

    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));

        itemToSpawn = Random.Range(0, 2);
        modifierToNeed = Random.Range(0, 2);
        SelectModifierNeeded();
        SelectItemGiven();
    }

    void SelectModifierNeeded()
    {
        switch (modifierToNeed)
        {
            case 0:
                gameData.modifierNeeded = "magnet";
                break;

            case 1:
                gameData.modifierNeeded = "microwave";
                break;

            default:
                break;
        }
    }

    void SelectItemGiven()
    {
        switch (itemToSpawn)
        {
            case 0:
                gameData.trinketGiven = "dagger";
                break;

            case 1:
                gameData.trinketGiven = "pocket watch";
                break;

            default:
                break;
        }
    }

    public void SpawnItem()
    {
        if (!spawnedItem)
        {
            Instantiate(trinketPrefab[itemToSpawn], spawnLocation, new Quaternion(0, 0, 0, 0));
            spawnedItem = true;
        }
    }
}
