using UnityEngine;

public class RiffleFireControllerCreator : MonoBehaviour, Creator<RiffleFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;

    public void Init(OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        this.onAmmoShotListener = onAmmoShotListener;
        this.onBulletCollideListener = onBulletCollideListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
    }

    public RiffleFireController Create(GameObject prefab, Transform target)
    {
        var riffleFireController = parentObjectCreator.Create(prefab, target).GetComponent<RiffleFireController>();
        riffleFireController.Init(weaponItem, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);

        return riffleFireController;
    }
    
    public WeaponItem WeaponItem
    {
        get => weaponItem;
        set => weaponItem = value;
    }

}
