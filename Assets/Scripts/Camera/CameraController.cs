using UnityEngine;

public class CameraController : MonoBehaviour, Activator, Deactivator
{
    [SerializeField]
    private CameraFollower cameraFollower;
    [SerializeField]
    private CameraGazer cameraGazer;
    private Transform target;

    void LateUpdate()
    {
        if (cameraFollower.enabled)
        {
            cameraFollower.Follow(target);
        }
        if (cameraGazer.enabled)
        {
            cameraGazer.Gaze(target);
        }
    }

    public void Activate()
    {
        enabled = true;

        cameraFollower.Activate();
        cameraGazer.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        
        cameraFollower.Deactivate();
        cameraGazer.Deactivate();
    }

    public Transform Target
    {
        get => target;
        set => target = value;
    }

}
