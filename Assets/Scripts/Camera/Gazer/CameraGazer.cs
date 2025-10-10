using UnityEngine;

public class CameraGazer : MonoBehaviour, Gazer, Activator, Deactivator
{
    public void Gaze(Transform target)
    {
        transform.LookAt(target.position);
    }

    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

}
