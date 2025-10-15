using UnityEngine;

public class RiffleFireControllerCreator : MonoBehaviour, Creator<RiffleFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;

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

    public OnAmmoShotListener OnAmmoShotListener
    {
        get => onAmmoShotListener;
        set => onAmmoShotListener = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        get => onBulletCollideListener;
        set => onBulletCollideListener = value;
    }

    public OnSetCameraOnShotPlayerListener OnSetCameraOnShotPlayerListener
    {
        get => onSetCameraOnShotPlayerListener;
        set => onSetCameraOnShotPlayerListener = value;
    }

}
