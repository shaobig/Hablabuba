using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private DamageHandlerFactory damageHandlerFactory;
    private Bullet bullet;

    public void Init(Bullet bullet, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener, OnBulletCollideListener onBulletCollideListener)
    {
        this.bullet = bullet;
        damageHandlerFactory.Init(onSetOnShotPlayerCameraListener, onBulletCollideListener);
    }

    void OnCollisionEnter(Collision collision)
    {
        damageHandlerFactory.GetDamageHandler(bullet.Type).HandleDamage(collision, bullet);
        gameObjectRemover.Remove(gameObject);
    }
    
}
