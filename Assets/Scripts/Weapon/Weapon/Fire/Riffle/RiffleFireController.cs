using UnityEngine;

public class RiffleFireController : MonoBehaviour, FireController
{
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;
    [SerializeField]
    private int velocity = 50;
    private WeaponItem weaponItem;
    private OnFireListener onFireListener;

    public void Init(
        WeaponItem weaponItem,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        this.weaponItem = weaponItem;
        this.onFireListener = onFireListener;

        ammoEmitter.Init(emitPoint, bulletPrefab, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.FIRE.Equals(fireAction))
        {
            ammoEmitter.Velocity = velocity;
            ammoEmitter.Emit();
            
            onFireListener.OnFire(weaponItem.Weapon.Type);
        }
    }
    
}
