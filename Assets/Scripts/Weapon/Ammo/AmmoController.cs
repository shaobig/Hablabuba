using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField]
    private LookRotationRigidbodyRotator ammoRigidbodyRotator;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    private new Rigidbody rigidbody;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onAmmoCollideListener = onAmmoCollideListener;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.rotation = ammoRigidbodyRotator.Rotate(rigidbody);
    }

    void OnCollisionEnter(Collision collision)
    {
        onAmmoCollideListener.OnAmmoCollide(collision);
        gameObjectRemover.Remove(gameObject);
    }
    
}
