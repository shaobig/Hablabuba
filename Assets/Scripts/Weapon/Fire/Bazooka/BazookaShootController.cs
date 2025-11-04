using UnityEngine;

public class BazookaShootController : MonoBehaviour, ShootController,
    OnTimerCountListener, OnTimerFinishListener, OnAmmoCollideListener
{
    [SerializeField]
    private AmmoShooterController loaderAmmoEmitter;
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private int velocity = 50;
    [SerializeField]
    private int radius = 40;
    private CollisionHandler<ExplosionCollisionContext> collisionHandler;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private ExplosionCollisionContext context;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        CollisionHandler<ExplosionCollisionContext> collisionHandler)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.collisionHandler = collisionHandler;

        weaponTimer.Init(this, this);
        loaderAmmoEmitter.Init(onAmmoShotListener, this);
    }

    public void Shoot(ShootAction action)
    {
        if (ShootAction.LONG_FIRE.Equals(action))
        {
            weaponTimer.Activate();
        }
        else if (ShootAction.STOP.Equals(action))
        {
            weaponTimer.Deactivate();
        }
    }

    public void OnTimerCount(float elapsedTime)
    {
        onWeaponProgressBarChangeValueListener.OnWeaponProgressBarChangeValue(1 - (elapsedTime / weaponTimer.MaxTime));
    }

    public void OnTimerFinish(float elapsedTime)
    {
        loaderAmmoEmitter.Velocity = Mathf.RoundToInt((1 - (elapsedTime / weaponTimer.MaxTime)) * velocity);
        loaderAmmoEmitter.Emit();

        onFireListener.OnFire(WeaponType.BAZOOKA);
    }

    public void OnAmmoCollide(Collision collision)
    {
        context = new ExplosionCollisionContextFactory(collision.GetContact(0).point, radius, loaderAmmoEmitter.AmmoPrefab.Ammo.Damage).Create();
        collisionHandler.HandleCollision(context);
    }

}
