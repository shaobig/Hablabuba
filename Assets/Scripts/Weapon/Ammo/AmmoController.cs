using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField]
    private LookRotationRigidbodyRotator ammoRigidbodyRotator;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    private new Rigidbody rigidbody;
    private OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener;

    public void Init(OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        this.onAmmoCollideWithTerrainListener = onAmmoCollideWithTerrainListener;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.rotation = ammoRigidbodyRotator.Rotate(rigidbody);
    }

    void OnCollisionEnter(Collision collision)
    {
        onAmmoCollideWithTerrainListener.OnAmmoCollideWithTerrain(collision);
        gameObjectRemover.Remove(gameObject);
    }
    
}
