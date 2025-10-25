using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    private OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener;

    public void Init(OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        this.onAmmoCollideWithTerrainListener = onAmmoCollideWithTerrainListener;
    }

    void OnCollisionEnter(Collision collision)
    {
        onAmmoCollideWithTerrainListener.OnAmmoCollideWithTerrain(collision);
        gameObjectRemover.Remove(gameObject);
    }
    
}
