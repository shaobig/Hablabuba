using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    private DamageHandlerFactory damageHandlerFactory;
    private Bullet bullet;
    private OnBulletCollideListener onBulletCollideListener;

    public void Init(Bullet bullet, OnBulletCollideListener onBulletCollideListener)
    {
        this.bullet = bullet;
        this.onBulletCollideListener = onBulletCollideListener;

        damageHandlerFactory = new DamageHandlerFactory();
    }

    void OnCollisionEnter(Collision collision)
    {
        damageHandlerFactory.GetDamageHandler(bullet.Type).HandleDamage(collision, bullet);
        onBulletCollideListener.OnBulletCollide();
        
        gameObjectRemover.Remove(gameObject);
    }

    void OnDestroy()
    {
        onBulletCollideListener = null;
    }

    public Bullet Bullet
    {
        get => bullet;
        set => bullet = value;
    }
    
}
