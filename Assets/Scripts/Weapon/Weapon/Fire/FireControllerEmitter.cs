using UnityEngine;

public class FireControllerEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;

    public void Init(
        AmmoPrefab ammoPrefab,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        ammoEmitter.Init(emitPoint, ammoPrefab, onAmmoShotListener, onAmmoCollideWithTerrainListener);
    }

    public void Emit()
    {
        ammoEmitter.Emit();
    }

    public int Velocity
    {
        set
        {
            ammoEmitter.Velocity = value;
        }
    }

}
