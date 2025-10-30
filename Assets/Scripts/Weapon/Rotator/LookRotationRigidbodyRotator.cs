using UnityEngine;

public class LookRotationRigidbodyRotator : MonoBehaviour, RigidbodyRotator
{
    public Quaternion Rotate(Rigidbody rigidbody)
    {
        return Quaternion.LookRotation(rigidbody.linearVelocity);
    }
}
