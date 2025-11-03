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
    private ShotCameraController shotPlayerCameraController;
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

        cameraActivator = new ListBlockCameraActivatorFactory(new() {playerCamera, ammoCamera, shotCamera, aimCamera}).Create();
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

    public void OnSetCameraOnObjectCompleted()
    {
        cameraActivator.ActivateCamera(CameraType.PLAYER);
        ammoCameraController.OnSetCameraOnObjectCompleted();
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
        if (ammoCameraController.IsAmmoFlown)
        {
            return;
        }
        cameraActivator.ActivateCamera(CameraType.PLAYER);
    }

}
