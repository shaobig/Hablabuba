using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraGameController : MonoBehaviour,
    OnAimTakenListener, OnAmmoShotListener, OnAmmoCollideListener, OnSetCameraOnObjectListener<List<PlayerController>>,
    OnAimKeyReleasedListener, OnSetCameraOnObjectCompletedListener
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
    private ActivatorController activatorController;
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

    public void Init(
        List<PlayerController> playerList,
        OnSetCameraOnObjectCompletedListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCameraController.Init(playerCamera, playerList);
        ammoCameraController.Init(ammoCamera);
        shotPlayerCameraController.Init(shotCamera, playerList, onSetCameraOnShotPlayerCompleteListener);
        aimCameraController.Init(aimCamera);

        activatorController.Init(new ListBlockCameraActivatorFactory(new() {playerCamera, ammoCamera, shotCamera, aimCamera}).Create());
    }

    public void Follow(Transform target)
    {
        activatorController.ActivateCamera(CameraType.PLAYER);
        playerCameraController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        activatorController.ActivateCamera(CameraType.AMMO);
        ammoCameraController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnObjectList(List<PlayerController> playerList)
    {
        activatorController.ActivateCamera(CameraType.SHOT);
        shotPlayerCameraController.OnSetCameraOnObjectList(playerList);
    }

    public void OnSetCameraOnObjectCompleted()
    {
        activatorController.OnSetCameraOnObjectCompleted();
        activatorController.ActivateCamera(CameraType.PLAYER);
    }

    public void OnAmmoCollide()
    {
        activatorController.OnAmmoCollide();
        activatorController.ActivateCamera(CameraType.PLAYER);
    }

    public void OnAimTaken(Transform aimPoint)
    {
        activatorController.ActivateCamera(CameraType.AIM);
        aimCameraController.OnAimTaken(aimPoint);
    }
    
    public void OnAimKeyReleased()
    {
        activatorController.ActivateCamera(CameraType.PLAYER);
    }

}
