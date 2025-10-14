using UnityEngine;

public class AmmoCameraController : MonoBehaviour, Activator, Deactivator,
    OnAmmoShotListener
{
    private Camera ammoCamera;
    private CameraController cameraController;

    public void Init(Camera ammoCamera)
    {
        this.ammoCamera = ammoCamera;

        ammoCamera.enabled = false;
        cameraController = ammoCamera.GetComponent<CameraController>();
        cameraController.Deactivate();
    }

    public void Activate()
    {
        ammoCamera.enabled = true;
        cameraController.Activate();
    }

    public void Deactivate()
    {
        ammoCamera.enabled = false;
        cameraController.Deactivate();
    }

    public void OnAmmoShot(Transform ammo)
    {
        cameraController.Target = ammo;
    }

}
