using UnityEngine;

public class RiffleFireControllerCreator : MonoBehaviour, Creator<RiffleFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;

    public void Init(
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onBulletCollideListener = onBulletCollideListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
    }

    public RiffleFireController Create(GameObject prefab, Transform target)
    {
        var riffleFireController = parentObjectCreator.Create(prefab, target).GetComponent<RiffleFireController>();
        riffleFireController.Init(weaponItem, onFireListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);

        return riffleFireController;
    }
    
    public WeaponItem WeaponItem
    {
        get => weaponItem;
        set => weaponItem = value;
    }

}
