using UnityEngine;

public class WeaponFireController : MonoBehaviour, Emitter
{
    [SerializeField]
    private WeaponEmitter weaponEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;

    public void Init(Weapon weapon, OnBulletCollideListener onBulletCollideListener)
    {
        weaponEmitter.Init(weapon, emitPoint, bulletPrefab, onBulletCollideListener);
    }

    public void Emit()
    {
        weaponEmitter.Emit();
    }

}
