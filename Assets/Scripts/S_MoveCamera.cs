using UnityEngine;
using UnityEngine.UI;

// This class manages the buttons that control the camera transitions

public class S_MoveCamera : MonoBehaviour
{
    public Camera _camera;
    public Button leftButton;
    public Button rightButton;

    void Start()
    {
        // Tie the buttons being clicked to their own events
        leftButton.onClick.AddListener(MoveCameraToShop);
        rightButton.onClick.AddListener(MoveCameraToWorkbench);

        // Disable the right button as they can't go to the workbench room from the workbench room
        rightButton.interactable = false;
    }

    void MoveCameraToShop()
    {
        // Play the transition for going to the shopfront
        _camera.SendMessage("PlayGoToShopAnimation");

        // You can go back to the workbench, but not to where you already are now
        leftButton.interactable = false;
        rightButton.interactable = true;
    }

    void MoveCameraToWorkbench()
    {
        _camera.SendMessage("PlayGoToWorkbenchAnimation");

        // You can go back to the shop, but not to where you already are now
        leftButton.interactable = true;
        rightButton.interactable = false;
    }
}
