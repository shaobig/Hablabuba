using Unity.Cinemachine;
using UnityEngine;

public class AmmoCameraController : MonoBehaviour, OnAmmoShotListener, OnSetCameraOnObjectCompleteListener
{
    private CinemachineCamera ammoCamera;
    private bool isAmmoFlown;

    public void Init(CinemachineCamera ammoCamera)
    {
        this.ammoCamera = ammoCamera;
    }

    public void OnAmmoShot(Transform ammo)
    {
        ammoCamera.Follow = ammo;
        isAmmoFlown = true;
    }

    public void OnSetCameraOnObjectCompleted()
    {
        isAmmoFlown = false;
    }

    public bool IsAmmoFlown => isAmmoFlown;

}
