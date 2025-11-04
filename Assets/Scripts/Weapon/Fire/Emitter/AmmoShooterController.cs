using UnityEngine;

public class AmmoShooterController : MonoBehaviour, Emitter
{
    [SerializeField]
    private VelocityAmmoEmitter velocityAmmoEmitter;
    [SerializeField]
    private LoadController loadController;
    private AmmoPrefab ammoPrefab;

    public void Init(
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        ammoPrefab = loadController.LoadAmmo();

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
