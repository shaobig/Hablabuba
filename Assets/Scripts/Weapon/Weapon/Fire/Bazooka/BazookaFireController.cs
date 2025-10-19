using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener
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
    private int velocity = 30;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;

    public void Init(
        WeaponItem weaponItem,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        this.weaponItem = weaponItem;
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;

        weaponTimer.Init(this, this);
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

}
