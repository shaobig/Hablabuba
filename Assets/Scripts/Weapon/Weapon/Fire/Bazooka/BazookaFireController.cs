using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener, OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private AmmoPrefab ammoPrefab;
    [SerializeField]
    private int velocity = 30;
    private CollisionHandler<ExplosionCollisionContext> collisionHandler;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;

    public void Init(
        WeaponItem weaponItem,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.weaponItem = weaponItem;
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;

        collisionHandler = new ExplosionListenerCollisionHandler(onSetCameraOnShotPlayerListener, onAmmoCollideListener);

        weaponTimer.Init(this, this);
        ammoEmitter.Init(emitPoint, ammoPrefab, onAmmoShotListener, this);
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
        ammoEmitter.Velocity = Mathf.RoundToInt((1 - (elapsedTime / weaponTimer.MaxTime)) * velocity);
        ammoEmitter.Emit();

        onFireListener.OnFire(weaponItem.Weapon.Type);
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new ExplosionCollisionContextImpl(collision.GetContact(0).point, ammoPrefab.Ammo.Radius, ammoPrefab.Ammo.Damage));
    }

}
