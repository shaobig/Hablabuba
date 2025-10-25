using UnityEngine;

public class InitGrenadeFireControllerCreator : MonoBehaviour, Creator<GrenadeFireController>
{
    [SerializeField]
    private GrenadeFireControllerCreator grenadeFireControllerCreator;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        var grenadeFireController = grenadeFireControllerCreator.Create(prefab, target);
        grenadeFireController.Init(weaponItem, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);

        return grenadeFireController;
    }

    public WeaponItem WeaponItem
    {
        set => weaponItem = value;
    }

}
