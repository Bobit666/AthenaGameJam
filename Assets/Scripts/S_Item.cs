using UnityEngine;

// This class handles the item prefab's collision and sprite (an enumerator decides its sprite)

public class S_Item : MonoBehaviour
{
    private GameObject trinketToAttachTo;
    private bool inContactWithAnvil;
    private int tinkCount;
    public SO_GameData gameData;
    private ParticleSystem _particleSystem;
    public Material doneParticle;
    private bool completed = false;

    private void Start()
    {
        gameData.itemAttached = false;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Called by the trinket once it overlaps the trigger
    void Collided(GameObject trinketOverlapped)
    {
        // Remember the trinket that it is overlapping
        trinketToAttachTo = trinketOverlapped;
    }

    // Called by the trinket once it leaves the trigger
    void LeftCollision(GameObject trinketOverlapped)
    {
        trinketToAttachTo = null;
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
        if (!completed)
        {
            // If both items involved are touching the anvil
            if (inContactWithAnvil && gameData.trinketInContactWithAnvil)
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
            if (tinkCount >= 5 && trinketToAttachTo != null)
            {
                var main = _particleSystem.main;
                var particleRenderer = _particleSystem.GetComponent<ParticleSystemRenderer>();

                particleRenderer.material = doneParticle;

                main.startColor = Color.white;
                main.startSpeed = 25f;
                _particleSystem.Play();

                // Attach to the trinket
                trinketToAttachTo.SendMessage("StayTogether");
                completed = true;
            }
        }
    }  
}
