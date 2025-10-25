using UnityEngine;

public class RifleFireControllerCreator : MonoBehaviour, Creator<RifleFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
    }

    public RifleFireController Create(GameObject prefab, Transform target)
    {
        var rifleFireController = parentObjectCreator.Create(prefab, target).GetComponent<RifleFireController>();
        rifleFireController.Init(weaponItem, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);

        return rifleFireController;
    }
    
    public WeaponItem WeaponItem
    {
        get => weaponItem;
        set => weaponItem = value;
    }

}
