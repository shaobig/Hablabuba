using UnityEngine;

public class WeaponFireController : MonoBehaviour, Emitter
{
    [SerializeField]
    private WeaponEmitter weaponEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;

    public void Init(Weapon weapon, OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        weaponEmitter.Init(weapon, emitPoint, bulletPrefab, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
    }

    public void Emit()
    {
        weaponEmitter.Emit();
    }

}
