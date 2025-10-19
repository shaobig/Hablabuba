using UnityEngine;

public class AmmoEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private InitBulletControllerCreator bulletControllerCreator;
    private Transform emitPoint;
    private BulletPrefab bulletPrefab;
    private float velocity;

    public void Init(
        Transform emitPoint,
        BulletPrefab bulletPrefab,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        this.emitPoint = emitPoint;
        this.bulletPrefab = bulletPrefab;

        bulletControllerCreator.Init(bulletPrefab.Bullet, onAmmoShotListener, onSetOnShotPlayerCameraListener, onBulletCollideListener);
    }

    public void Emit()
    {
        var bulletRigidbody = bulletControllerCreator.Create(bulletPrefab.Prefab, emitPoint).GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = emitPoint.forward * velocity;
    }

    public int Velocity
    {
        set => velocity = value;
    }
    
}
