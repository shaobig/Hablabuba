using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerFinishListener
{
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;
    [SerializeField]
    private int velocity;
    private Weapon weapon;
    private OnFireListener onFireListener;

    public void Init(
        WeaponItem weaponItem,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        this.onFireListener = onFireListener;
        
        weapon = weaponItem.Weapon;

        weaponTimer.Init(onWeaponProgressBarChangeValueListener, this);
        ammoEmitter.Init(emitPoint, bulletPrefab, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
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

    public void OnTimerFinish(float elapsedTime)
    {
        ammoEmitter.Velocity = Mathf.RoundToInt(elapsedTime / weaponTimer.MaxTime * velocity);
        ammoEmitter.Emit();

        onFireListener.OnFire(weapon.Type);
    }

}
