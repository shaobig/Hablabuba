using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraGameController : MonoBehaviour,
    OnAmmoShotListener, OnBulletCollideListener, OnSetCameraOnShotPlayerListener
{
    private const int INACTIVE_CAMERA_PRIORITY = 0;
    private const int ACTIVE_CAMERA_PRIORITY = 1;

    [SerializeField]
    private PlayerCameraController playerCameraController;
    [SerializeField]
    private AmmoCameraController ammoCameraController;
    [SerializeField]
    private ShotPlayerCameraController shotPlayerCameraController;
    [SerializeField]
    private CinemachineBrain cameraController;
    [SerializeField]
    private CinemachineCamera playerCamera;
    [SerializeField]
    private CinemachineCamera ammoCamera;
    [SerializeField]
    private CinemachineCamera shotPlayerCamera;

    public void Init(
        List<PlayerController> playerList,
        OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        ammoCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        shotPlayerCamera.Priority = INACTIVE_CAMERA_PRIORITY;

        playerCameraController.Init(playerCamera, playerList);
        ammoCameraController.Init(ammoCamera);
        shotPlayerCameraController.Init(shotPlayerCamera, playerList, onSetCameraOnShotPlayerCompleteListener);
    }

    public void Follow(Transform target)
    {
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        playerCameraController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        ammoCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        ammoCameraController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        shotPlayerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        shotPlayerCameraController.OnSetCameraOnShotPlayer(playerList);
    }

    public void OnBulletCollide()
    {
        ammoCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
    }

}
