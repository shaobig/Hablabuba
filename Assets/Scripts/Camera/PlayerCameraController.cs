using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 1.5f;
    private Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            FollowPlayer();
            LookAtPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.position = target.position + Vector3.up * height - target.forward * distance;
    }

    void LookAtPlayer()
    {
        transform.LookAt(target.position);
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

}
