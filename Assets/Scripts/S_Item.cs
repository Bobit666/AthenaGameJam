using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

// This class handles the item prefab's collision and sprite (an enumerator decides its sprite)

public class S_Item : MonoBehaviour
{
    private bool inArea = false;
    private GameObject trinketToAttachTo;
    private bool inContactWithAnvil;
    private int tinkCount;
    public SO_GameData gameData;
    private bool attached = false;
    private ParticleSystem _particleSystem;
    public Material doneParticle;

    private void Start()
    {
        gameData.itemAttached = false;
        gameData.itemAttachedPermanently = false;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Called by the trinket once it overlaps the trigger
    void Collided(GameObject trinketOverlapped)
    {
        // Remember the trinket that it is overlapping
        trinketToAttachTo = trinketOverlapped;

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
            trinketToAttachTo.SendMessage("AttachItem");
            gameObject.tag = "AttachedModifier";
        }
    }

    // Sent by S_Attach
    void Attached(bool areYouAttached)
    {
        attached = areYouAttached;
    }

    // Sent by S_Anvil
    void ContactWithAnvil(bool InContact)
    {
        inContactWithAnvil = InContact;
    }

    // Whenever the hammer collides with this item
    void HammerHit(float hitStrength)
    {
        
        print(tinkCount);
        // If attached AND if either this item OR the trinket is in contact with the anvil
        if (attached && inContactWithAnvil || gameData.trinketInContactWithAnvil)
        {
            var main = _particleSystem.main;
            // If the player hammers the item softly
            if (hitStrength < 8 && hitStrength > 3)
            {
                print("Tink");
                tinkCount++;

                main.startColor = Color.white;
                main.startSpeed = 25f;
                _particleSystem.Play();
            }
            // If the player hammers the item hard
            else if (hitStrength > 8)
            {
                print("Clank");
                tinkCount--;

                main.startColor = Color.red;
                main.startSpeed = 50f;
                _particleSystem.Play();
            }
        }

        // If the player has hit the item softly 5 times
        if (tinkCount >= 5)
        {
            var main = _particleSystem.main;
            var particleRenderer = _particleSystem.GetComponent<ParticleSystemRenderer>();

            particleRenderer.material = doneParticle;

            main.startColor = Color.white;
            main.startSpeed = 25f;
            _particleSystem.Play();
            trinketToAttachTo.SendMessage("StayTogether");
        }
    }
}
