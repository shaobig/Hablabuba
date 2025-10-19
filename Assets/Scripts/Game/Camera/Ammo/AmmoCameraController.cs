using Unity.Cinemachine;
using UnityEngine;

public class AmmoCameraController : MonoBehaviour, OnAmmoShotListener
{
    private CinemachineCamera ammoCamera;

    public void Init(CinemachineCamera ammoCamera)
    {
        this.ammoCamera = ammoCamera;
    }

    public void OnAmmoShot(Transform ammo)
    {
        ammoCamera.Follow = ammo;
    }

}
