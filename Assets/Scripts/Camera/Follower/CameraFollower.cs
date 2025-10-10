using UnityEngine;

public class CameraFollower : MonoBehaviour, Follower, Activator, Deactivator
{
    [SerializeField] 
    private float distance = 5f;
    [SerializeField] 
    private float height = 1.5f;

    public void Follow(Transform target)
    {
        transform.position = target.position + Vector3.up * height - target.forward * distance;
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
