using UnityEngine;

public class RifleFireController : MonoBehaviour, AimShootController,
    OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private AmmoShooterController ammoFireController;
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

        ammoFireController.Init(onAmmoShotListener, this);
        ammoFireController.Velocity = velocity;

        aimController.Init(onAimTakenListener);
    }

    public void Shoot(ShootAction action)
    {
        if (ShootAction.FIRE.Equals(action))
        {
            ammoFireController.Emit();
            onFireListener.OnFire(WeaponType.RIFLE);
        }
    }

    public void TakeAim()
    {
        aimController.TakeAim();
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new RifleCollisionContextFactory(collision, ammoFireController.AmmoPrefab).Create());
    }

}
