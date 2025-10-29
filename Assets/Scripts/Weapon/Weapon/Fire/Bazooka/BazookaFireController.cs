using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener, OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private FireControllerEmitter ammoFireController;
    [SerializeField]
    private FireControllerAmmoLoader fireControllerAmmoLoader;
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private float velocity = 50;
    [SerializeField]
    private int radius = 40;
    private AmmoPrefab ammoPrefab;
    private CollisionHandler<ExplosionCollisionContext> collisionHandler;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;

        collisionHandler = new ExplosionListenerCollisionHandler(onSetCameraOnShotPlayerListener, onAmmoCollideListener);
        ammoPrefab = fireControllerAmmoLoader.LoadAmmo();

        weaponTimer.Init(this, this);
        ammoFireController.Init(ammoPrefab, onAmmoShotListener, this);
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
        ammoFireController.Velocity = Mathf.RoundToInt((1 - (elapsedTime / weaponTimer.MaxTime)) * velocity);
        ammoFireController.Emit();

        onFireListener.OnFire(WeaponType.BAZOOKA);
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new ExplosionCollisionContextFactory(collision.GetContact(0).point, radius, ammoPrefab.Ammo.Damage).Create());
    }

}
