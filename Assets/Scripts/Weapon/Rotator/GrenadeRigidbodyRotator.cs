using UnityEngine;

public class GrenadeRigidbodyRotator : MonoBehaviour, RigidbodyRotator
{
    [SerializeField]
    private LookRotationRigidbodyRotator lookRotationRigidbodyRotator;

    public Quaternion Rotate(Rigidbody rigidbody)
    {
        return Vector3.zero == rigidbody.linearVelocity ? Quaternion.identity : lookRotationRigidbodyRotator.Rotate(rigidbody);
    }

}
