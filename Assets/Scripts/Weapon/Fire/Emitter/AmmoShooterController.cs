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
        OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        ammoPrefab = ShooterAmmoLoader.LoadAmmo();

        velocityAmmoEmitter.Init(ammoPrefab, onAmmoShotListener, onAmmoCollideWithTerrainListener);
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
