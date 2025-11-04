using UnityEngine;

public class RifleFireController : MonoBehaviour, AimShootController,
    OnAmmoCollideListener
{
    [SerializeField]
    private AmmoShooterController ammoShooterController;
    [SerializeField]
    private AimController aimController;
    [SerializeField]
    private int velocity = 25;
    private CollisionHandler<RifleCollisionContext> collisionHandler;
    private OnFireListener onFireListener;

    public void Init(
        CollisionHandler<RifleCollisionContext> collisionHandler,
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener)
    {
        this.collisionHandler = collisionHandler;
        this.onFireListener = onFireListener;

        ammoShooterController.Init(onAmmoShotListener, this);
        ammoShooterController.Velocity = velocity;

        aimController.Init(onAimTakenListener);
    }

    public void Shoot(ShootAction action)
    {
        if (ShootAction.FIRE.Equals(action))
        {
            ammoShooterController.Emit();
            onFireListener.OnFire(WeaponType.RIFLE);
        }
    }

    public void TakeAim()
    {
        aimController.TakeAim();
    }

    public void OnAmmoCollide(Collision collision)
    {
        collisionHandler.HandleCollision(new RifleCollisionContextFactory(collision, ammoShooterController.AmmoPrefab).Create());
    }

}
