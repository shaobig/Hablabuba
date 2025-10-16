using UnityEngine;

public class AmmoEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private InitBulletControllerCreator bulletControllerCreator;
    private Transform emitPoint;
    private BulletPrefab bulletPrefab;
    private int speed;

    public void Init(Transform emitPoint, BulletPrefab bulletPrefab, int speed, OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        this.emitPoint = emitPoint;
        this.bulletPrefab = bulletPrefab;
        this.speed = speed;

        bulletControllerCreator.Init(bulletPrefab.Bullet, onAmmoShotListener, onSetOnShotPlayerCameraListener, onBulletCollideListener);
    }

    public void Emit()
    {
        var bulletRigidbody = bulletControllerCreator.Create(bulletPrefab.Prefab, emitPoint).GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = emitPoint.forward * speed;
    }

    public int Speed
    {
        get => speed;
        set => speed = value;
    }
    
}
