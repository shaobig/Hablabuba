using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerCameraController : MonoBehaviour, Activator, Deactivator,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private ShotPlayerCameraHandler shotPlayerCameraHandler;

    public void Init(Camera shotPlayerCamera, List<PlayerController> playerList, OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        shotPlayerCamera.enabled = false;
        var cameraController = shotPlayerCamera.GetComponent<CameraController>();
        cameraController.Deactivate();

        shotPlayerCameraHandler.Init(shotPlayerCamera, cameraController, playerList, onSetCameraOnShotPlayerCompleteListener);
    }

    public void Activate()
    {
        enabled = true;
        shotPlayerCameraHandler.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        shotPlayerCameraHandler.Deactivate();
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        shotPlayerCameraHandler.OnSetCameraOnShotPlayer(playerList);
    }

}
