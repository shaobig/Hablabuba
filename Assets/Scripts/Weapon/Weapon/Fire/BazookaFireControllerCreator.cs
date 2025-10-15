using UnityEngine;

public class BazookaFireControllerCreator : MonoBehaviour, Creator<BazookaFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;

    public BazookaFireController Create(GameObject prefab, Transform target)
    {
        var bazookaFireController = parentObjectCreator.Create(prefab, target).GetComponent<BazookaFireController>();
        bazookaFireController.Init(weaponItem, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);

        return bazookaFireController;
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
