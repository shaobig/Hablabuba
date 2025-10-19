using UnityEngine;

public class CameraGazer : MonoBehaviour, Activator, Deactivator, Gazer
{
    public void Gaze(Transform target)
    {
        transform.LookAt(target);
    }

    public void Activate() => enabled = true;
    public void Deactivate() => enabled = false;

}
