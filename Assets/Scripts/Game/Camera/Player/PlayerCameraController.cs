using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour, Activator, Deactivator, Follower
{
    [SerializeField]
    private PlayerListDisplayRefresher playerListDisplayRefresher;
    private Camera playerCamera;
    private CameraController cameraController;

    public void Init(Camera playerCamera, List<PlayerController> playerList)
    {
        this.playerCamera = playerCamera;

        playerCamera.enabled = true;
        cameraController = playerCamera.GetComponent<CameraController>();
        cameraController.Activate();

        playerListDisplayRefresher.Init(playerCamera, playerList);
    }

    void LateUpdate()
    {
        if (playerCamera.enabled)
        {
            playerListDisplayRefresher.RefreshDisplay();
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
