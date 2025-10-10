using UnityEngine;

public class WeaponEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private InitBulletControllerCreator bulletControllerCreator;
    private Weapon weapon;
    private Transform emitPoint;
    private BulletPrefab bulletPrefab;

    public void Init(Weapon weapon, Transform emitPoint, BulletPrefab bulletPrefab, OnBulletCollideListener onBulletCollideListener)
    {
        this.weapon = weapon;
        this.emitPoint = emitPoint;
        this.bulletPrefab = bulletPrefab;

        bulletControllerCreator.Init(bulletPrefab.Bullet, onBulletCollideListener);
    }

    public void Emit()
    {
        var bulletRigidbody = bulletControllerCreator.Create(bulletPrefab.Prefab, emitPoint).GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = emitPoint.forward * weapon.Speed;
    }
    
}
