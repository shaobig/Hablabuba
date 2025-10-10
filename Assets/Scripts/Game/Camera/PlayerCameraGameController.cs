using UnityEngine;

public class PlayerCameraGameController : MonoBehaviour, Follower, Deactivator,
    OnBulletCollideListener
{
    private Camera camera;
    private CameraController cameraController;

    public void Init(Camera camera)
    {
        this.camera = camera;

        camera.enabled = true;
        cameraController = camera.GetComponent<CameraController>();
        cameraController.Activate();
    }

    public void Follow(Transform target)
    {
        cameraController.Target = target;
    }

    public void Deactivate()
    {
        camera.enabled = false;
        cameraController.Deactivate();
    }

    public void OnBulletCollide()
    {
        camera.enabled = true;
        cameraController.Activate();
    }

}
