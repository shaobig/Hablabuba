using UnityEngine;

public class VelocityAmmoEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;

    public void Init(
        AmmoPrefab ammoPrefab,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        ammoEmitter.Init(emitPoint, ammoPrefab, onAmmoShotListener, onAmmoCollideListener);
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
