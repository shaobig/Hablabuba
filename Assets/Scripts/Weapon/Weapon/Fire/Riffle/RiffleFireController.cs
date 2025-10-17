using UnityEngine;

public class RiffleFireController : MonoBehaviour, FireController
{
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;

    public void Init(WeaponItem weaponItem, OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        ammoEmitter.Init(emitPoint, bulletPrefab, weaponItem.Weapon.Speed, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.START.Equals(fireAction))
        {
            ammoEmitter.Emit();
        }
    }
    
}
