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
    private Weapon weapon;

    public void Init(
        WeaponItem weaponItem,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        weapon = weaponItem.Weapon;

        weaponTimer.Init(onWeaponProgressBarChangeValueListener, this);
        ammoEmitter.Init(emitPoint, bulletPrefab, weaponItem.Weapon.Speed, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
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
        ammoEmitter.Speed = Mathf.RoundToInt(elapsedTime / weaponTimer.MaxTime * weapon.Speed);
        ammoEmitter.Emit();
    }

}
