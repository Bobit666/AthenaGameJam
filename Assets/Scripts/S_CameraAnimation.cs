using UnityEngine;

// This class handles the animations that the camera uses to move between rooms

public class S_CameraAnimation : MonoBehaviour
{
    public AnimationClip goToShop;
    public AnimationClip goToBench;
    public Animation moveCamAnim;

    void PlayGoToShopAnimation()
    {
        // Select the goToShop transition and then play it
        moveCamAnim.clip = goToShop;
        moveCamAnim.Play();
    }

    void PlayGoToWorkbenchAnimation()
    {
        // Select the goToBench transition and then play it
        moveCamAnim.clip = goToBench;
        moveCamAnim.Play();
    }
}
