using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraGameController : MonoBehaviour, Activator, Deactivator, Follower
{
    private Camera playerCamera;
    private CameraController cameraController;
    private List<PlayerController> playerList;

    public void Init(Camera playerCamera, List<PlayerController> playerList)
    {
        this.playerCamera = playerCamera;

        playerCamera.enabled = true;
        cameraController = playerCamera.GetComponent<CameraController>();
        cameraController.Activate();

        this.playerList = playerList;
    }

    void LateUpdate()
    {
        if (playerCamera.enabled)
        {
            playerList.ForEach(player =>
            {
                player.Camera = playerCamera.transform;
                player.RefreshDisplay();
            });
        }
    }

    public void Activate()
    {
        playerCamera.enabled = true;
        cameraController.Activate();
    }

    public void Deactivate()
    {
        playerCamera.enabled = false;
        cameraController.Deactivate();
    }

    public void Follow(Transform target)
    {
        cameraController.Target = target;
    }

}
