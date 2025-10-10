using UnityEngine;

public class InitBulletControllerCreator : MonoBehaviour, Creator<BulletController>
{
    [SerializeField]
    private BulletControllerCreator bulletControllerCreator;
    private Bullet bullet;
    private OnBulletCollideListener onBulletCollideListener;

    public void Init(Bullet bullet, OnBulletCollideListener onBulletCollideListener)
    {
        this.bullet = bullet;
        this.onBulletCollideListener = onBulletCollideListener;
    }

    public BulletController Create(GameObject bulletPrefab, Transform emitPoint)
    {
        var bulletController = bulletControllerCreator.Create(bulletPrefab, emitPoint);
        bulletController.Init(bullet, onBulletCollideListener);

        return bulletController;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        get => onBulletCollideListener;
        set => onBulletCollideListener = value;
    }

}
