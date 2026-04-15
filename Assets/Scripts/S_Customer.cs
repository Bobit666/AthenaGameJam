using UnityEngine;

// This class handles the customer appearing, disappearing, spawning trinkets and deciding on what trinket and modifier to give/need

public class S_Customer : MonoBehaviour
{
    public GameObject[] trinketPrefab;
    private int itemToSpawn;
    private int modifierToNeed;
    private Vector3 spawnLocation = new Vector3(-20f, 0f, 0f);

    public SO_GameData gameData;

    private bool spawnedItem = false;

    private SpriteRenderer _renderer;

    private Animation _animation;
    public AnimationClip appearAnim;
    public AnimationClip disappearAnim;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        // Randomly colour the customer's sprite
        _renderer.material.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
        _animation = GetComponent<Animation>();

        // Randomly decide what item to spawn and what modifier to need
        itemToSpawn = Random.Range(0, trinketPrefab.Length);
        modifierToNeed = Random.Range(0, 4);
        SelectModifierNeeded();
        SelectItemGiven();

        // Play animation for appearing
        Appear();
    }

    // Decide on what modifier item to ask for
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

            case 2:
                gameData.modifierNeeded = "fan";
                break;

            case 3:
                gameData.modifierNeeded = "thruster";
                    break;

            default:
                break;
        }
    }

    // Decide on what trinket to give
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

            case 2:
                gameData.trinketGiven = "locket";
                break;

            case 3:
                gameData.trinketGiven = "shield";
                break;

            default:
                break;
        }
    }

    // Spawns the trinket that they decide on
    public void SpawnItem()
    {
        if (!spawnedItem)
        {
            Instantiate(trinketPrefab[itemToSpawn], spawnLocation, new Quaternion(0, 0, 0, 0));
            spawnedItem = true;
        }
    }

    // Animation for appearing
    void Appear()
    {
        _animation.clip = appearAnim;
        _animation.Play();
    }

    // Animation for disappearing
    void Disappear()
    {
        _animation.clip = disappearAnim;
        _animation.Play();
        Destroy(gameObject, 1f);
    }
}
