using UnityEngine;

public class AmmoShooterController : MonoBehaviour, Emitter
{
    [SerializeField]
    private VelocityAmmoEmitter velocityAmmoEmitter;
    [SerializeField]
    private LoadController ShooterAmmoLoader;
    private AmmoPrefab ammoPrefab;

    public void Init(
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        ammoPrefab = ShooterAmmoLoader.LoadAmmo();

        velocityAmmoEmitter.Init(ammoPrefab, onAmmoShotListener, onAmmoCollideListener);
    }

    public void Emit()
    {
        velocityAmmoEmitter.Emit();
    }

    public AmmoPrefab AmmoPrefab => ammoPrefab;

    public int Velocity
    {
        set => velocityAmmoEmitter.Velocity = value;
    }

}
