using System.Collections.Generic;
using UnityEngine;

public class CameraGameController : MonoBehaviour, Follower,
    OnAmmoShotListener, OnBulletCollideListener, OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private PlayerCameraController playerCameraController;
    [SerializeField]
    private AmmoCameraController ammoCameraController;
    [SerializeField]
    private ShotPlayerCameraController shotPlayerCameraController;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Camera ammoCamera;
    [SerializeField]
    private Camera shotPlayerCamera;

    public void Init(List<PlayerController> playerList, OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        playerCameraController.Init(playerCamera, playerList);
        ammoCameraController.Init(ammoCamera);
        shotPlayerCameraController.Init(shotPlayerCamera, playerList, onSetCameraOnShotPlayerCompleteListener);
    }

    public void Follow(Transform target)
    {
        playerCameraController.Follow(target);
    }

    public void OnAmmoShot(Transform ammo)
    {
        playerCameraController.Deactivate();
        ammoCameraController.Activate();

        ammoCameraController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        ammoCameraController.Deactivate();
        shotPlayerCameraController.Activate();

        shotPlayerCameraController.OnSetCameraOnShotPlayer(playerList);
    }

    public void OnBulletCollide()
    {
        ammoCameraController.Deactivate();
        playerCameraController.Activate();
    }

}
