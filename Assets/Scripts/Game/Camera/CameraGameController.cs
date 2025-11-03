using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraGameController : MonoBehaviour,
    OnAimTakenListener, OnAmmoShotListener, OnAmmoCollideListener, OnSetCameraOnObjectListener<List<PlayerController>>, OnSetCameraOnObjectCompleteListener
{
    private const int INACTIVE_CAMERA_PRIORITY = 0;
    private const int ACTIVE_CAMERA_PRIORITY = 1;

    [SerializeField]
    private PlayerCameraController playerCameraController;
    [SerializeField]
    private AmmoCameraController ammoCameraController;
    [SerializeField]
    private ShotObjectCameraController shotPlayerCameraController;
    [SerializeField]
    private AimCameraController aimCameraController;
    [SerializeField]
    private CinemachineBrain mainCamera;
    [SerializeField]
    private CinemachineCamera playerCamera;
    [SerializeField]
    private CinemachineCamera ammoCamera;
    [SerializeField]
    private CinemachineCamera shotObjectCamera;
    [SerializeField]
    private CinemachineCamera aimCamera;

    public void Init(
        List<PlayerController> playerList,
        OnSetCameraOnObjectCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        ammoCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        shotObjectCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        aimCamera.Priority = INACTIVE_CAMERA_PRIORITY;

        playerCameraController.Init(playerCamera, playerList);
        ammoCameraController.Init(ammoCamera);
        shotPlayerCameraController.Init(shotObjectCamera, playerList, onSetCameraOnShotPlayerCompleteListener);
        aimCameraController.Init(aimCamera);
    }

    public void Follow(Transform target)
    {
        playerCameraController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        playerCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        ammoCamera.Priority = ACTIVE_CAMERA_PRIORITY;

        ammoCameraController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnObjectList(List<PlayerController> playerList)
    {
        ammoCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        shotObjectCamera.Priority = ACTIVE_CAMERA_PRIORITY;

        shotPlayerCameraController.OnSetCameraOnObjectList(playerList);
    }

    public void OnSetCameraOnObjectComplete()
    {
        shotObjectCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
    }

    public void OnAmmoCollide()
    {
        ammoCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        playerCamera.Priority = ACTIVE_CAMERA_PRIORITY;
    }

    public void OnAimTaken(Transform aimPoint)
    {
        playerCamera.Priority = INACTIVE_CAMERA_PRIORITY;
        aimCamera.Priority = ACTIVE_CAMERA_PRIORITY;
        
        aimCameraController.OnAimTaken(aimPoint);
    }

}
