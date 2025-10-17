using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerFinishListener
{
    [SerializeField]
    private BazookaTimer bazookaTimer;
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;
    private Weapon weapon;

    public void Init(WeaponItem weaponItem, OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        weapon = weaponItem.Weapon;

        bazookaTimer.Init(this);
        ammoEmitter.Init(emitPoint, bulletPrefab, weaponItem.Weapon.Speed, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.START.Equals(fireAction))
        {
            bazookaTimer.Activate();
        }
        else if (FireAction.RELEASE.Equals(fireAction))
        {
            bazookaTimer.Deactivate();
        }
    }

    public void OnTimerFinish(float elapsedTime)
    {
        ammoEmitter.Speed = Mathf.RoundToInt(elapsedTime / bazookaTimer.MaxTime * weapon.Speed);
        ammoEmitter.Emit();
    }

}
