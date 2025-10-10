using System.Collections.Generic;
using UnityEngine;

public class CameraGameController : MonoBehaviour, Follower,
    OnAmmoShotListener, OnBulletCollideListener, OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private PlayerCameraGameController playerCameraGameController;
    [SerializeField]
    private AmmoCameraGameController ammoCameraGameController;
    [SerializeField]
    private ShotPlayerCameraGameController shotPlayerCameraGameController;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Camera ammoCamera;
    [SerializeField]
    private Camera shotPlayerCamera;

    public void Init(OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCameraGameController.Init(playerCamera);
        ammoCameraGameController.Init(ammoCamera);
        shotPlayerCameraGameController.Init(shotPlayerCamera, onSetCameraOnShotPlayerCompleteListener);
    }

    public void Follow(Transform target)
    {
        playerCameraGameController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        playerCameraGameController.Deactivate();
        ammoCameraGameController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        ammoCameraGameController.Deactivate();
        shotPlayerCameraGameController.OnSetCameraOnShotPlayer(playerList);
    }

    public void OnBulletCollide()
    {
        ammoCameraGameController.OnBulletCollide();
        playerCameraGameController.OnBulletCollide();
    }

}
