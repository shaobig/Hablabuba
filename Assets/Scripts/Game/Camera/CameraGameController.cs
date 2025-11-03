using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraGameController : MonoBehaviour,
    OnAimTakenListener, OnAmmoShotListener, OnAmmoCollideListener, OnSetCameraOnObjectListener<List<PlayerController>>,
    OnAimKeyReleasedListener, OnSetCameraOnObjectCompleteListener
{
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
    private CinemachineCamera shotCamera;
    [SerializeField]
    private CinemachineCamera aimCamera;
    private CameraActivator cameraActivator;

    public void Init(
        List<PlayerController> playerList,
        OnSetCameraOnObjectCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCameraController.Init(playerCamera, playerList);
        ammoCameraController.Init(ammoCamera);
        shotPlayerCameraController.Init(shotCamera, playerList, onSetCameraOnShotPlayerCompleteListener);
        aimCameraController.Init(aimCamera);

        cameraActivator = new ListGameCameraActivatorFactory(new() {playerCamera, ammoCamera, shotCamera, aimCamera}, playerCamera).Create();
    }

    public void Follow(Transform target)
    {
        cameraActivator.ActivateCamera(CameraType.PLAYER);
        playerCameraController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        cameraActivator.ActivateCamera(CameraType.AMMO);
        ammoCameraController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnObjectList(List<PlayerController> playerList)
    {
        cameraActivator.ActivateCamera(CameraType.SHOT);
        shotPlayerCameraController.OnSetCameraOnObjectList(playerList);
    }

    public void OnSetCameraOnObjectComplete()
    {
        cameraActivator.ActivateCamera(CameraType.PLAYER);
    }

    public void OnAmmoCollide()
    {
        cameraActivator.ActivateCamera(CameraType.PLAYER);
    }

    public void OnAimTaken(Transform aimPoint)
    {
        cameraActivator.ActivateCamera(CameraType.AIM);
        aimCameraController.OnAimTaken(aimPoint);
    }
    
    public void OnAimKeyReleased()
    {
        cameraActivator.ActivateCamera(CameraType.PLAYER);
    }

}
