using UnityEngine;

public class AmmoCameraGameController : MonoBehaviour, Deactivator,
    OnAmmoShotListener, OnBulletCollideListener
{
    private Camera camera;
    private CameraController cameraController;

    public void Init(Camera camera)
    {
        this.camera = camera;

        camera.enabled = false;
        cameraController = camera.GetComponent<CameraController>();
        cameraController.Deactivate();
    }

    public void Deactivate()
    {
        camera.enabled = false;
        cameraController.Deactivate();
    }

    
    public void OnAmmoShot(Transform ammo)
    {
        camera.enabled = true;
        
        cameraController.Target = ammo;
        cameraController.Activate();
    }

    public void OnBulletCollide()
    {
        camera.enabled = false;
        cameraController.Deactivate();
    }
    
    
}
