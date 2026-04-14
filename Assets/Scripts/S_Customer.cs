using UnityEngine;
using TMPro;

public class S_Customer : MonoBehaviour
{
    public GameObject[] trinketPrefab;
    private int itemToSpawn;
    public GameObject dialogueBox;
    private Vector3 spawnLocation = new Vector3(-20f, 0f, 0f);

    void Start()
    {
        itemToSpawn = Random.Range(0, 2);
        Invoke("SpawnItem", 2f);
    }

    void SpawnItem()
    {
        GameObject newTrinket = Instantiate(trinketPrefab[itemToSpawn], spawnLocation, new Quaternion(0,0,0,0));

        switch (itemToSpawn)
        {
            case 0:
                dialogueBox.GetComponent<TextMeshPro>().text = "Dagger";
                break;

            case 1:
                dialogueBox.GetComponent<TextMeshPro>().text = "Pocket Watch";
                break;

            default:
                break;
        }

        
    }
}
