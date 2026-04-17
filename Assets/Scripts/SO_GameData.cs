using UnityEngine;

// This ScriptableObject is used to store variables that will be used throughout the game and should be accessed by multiple objects

[CreateAssetMenu(fileName = "SO_GameData", menuName = "Scriptable Objects/SO_GameData")]
public class SO_GameData : ScriptableObject
{
    public string trinketGiven;
    public string modifierNeeded;
    public int coinCount;
    public bool trinketInContactWithAnvil;
    public bool itemAttached;
    public bool itemAttachedPermanently;
    public int modifiersInScene;
}
