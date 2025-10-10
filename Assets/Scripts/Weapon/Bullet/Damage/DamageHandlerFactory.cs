using UnityEngine;

public class DamageHandlerFactory: MonoBehaviour
{
    private OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener;
    private OnBulletCollideListener onBulletCollideListener;

    public void Init(OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener, OnBulletCollideListener onBulletCollideListener)
    {
        this.onSetOnShotPlayerCameraListener = onSetOnShotPlayerCameraListener;
        this.onBulletCollideListener = onBulletCollideListener;
    }

    public DamageHandler GetDamageHandler(BulletType type)
    {
        if (BulletType.BAZOOKA.Equals(type))
        {
            return new BazookaDamageHandler(onSetOnShotPlayerCameraListener, onBulletCollideListener);
        }
        else
        {
            return new RiffleDamageHandler(onSetOnShotPlayerCameraListener, onBulletCollideListener);
        }
    }

}
