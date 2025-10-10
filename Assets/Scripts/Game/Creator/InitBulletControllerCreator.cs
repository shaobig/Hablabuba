using UnityEngine;

public class InitBulletControllerCreator : MonoBehaviour, Creator<BulletController>
{
    [SerializeField]
    private BulletControllerCreator bulletControllerCreator;
    private Bullet bullet;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener;
    private OnBulletCollideListener onBulletCollideListener;

    public void Init(Bullet bullet, OnAmmoShotListener onAmmoShotListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener, OnBulletCollideListener onBulletCollideListener)
    {
        this.bullet = bullet;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetOnShotPlayerCameraListener = onSetOnShotPlayerCameraListener;
        this.onBulletCollideListener = onBulletCollideListener;
    }

    public BulletController Create(GameObject bulletPrefab, Transform emitPoint)
    {
        var bulletController = bulletControllerCreator.Create(bulletPrefab, emitPoint);
        bulletController.Init(bullet, onSetOnShotPlayerCameraListener, onBulletCollideListener);

        onAmmoShotListener.OnAmmoShot(bulletController.transform);

        return bulletController;
    }

}
