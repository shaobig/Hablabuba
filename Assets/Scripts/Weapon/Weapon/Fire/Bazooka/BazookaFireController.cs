using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener, OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private LoaderAmmoEmitter loaderAmmoEmitter;
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

    public void Fire(FireAction fireAction)
    {
        if (FireAction.LONG_FIRE.Equals(fireAction))
        {
            weaponTimer.Activate();
        }
        else if (FireAction.STOP.Equals(fireAction))
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

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        context = new ExplosionCollisionContextFactory(collision.GetContact(0).point, radius, loaderAmmoEmitter.AmmoPrefab.Ammo.Damage).Create();
        collisionHandler.HandleCollision(context);
    }

    void OnDrawGizmos()
    {
        if (context != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(context.ExplosionPoint, context.Radius);
        }
    }

}
