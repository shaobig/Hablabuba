using UnityEngine;

public class BazookaFireControllerCreator : MonoBehaviour, Creator<BazookaFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onBulletCollideListener = onBulletCollideListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
    }

    public BazookaFireController Create(GameObject prefab, Transform target)
    {
        var bazookaFireController = parentObjectCreator.Create(prefab, target).GetComponent<BazookaFireController>();
        bazookaFireController.Init(weaponItem, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);

        return bazookaFireController;
    }

    public WeaponItem WeaponItem
    {
        get => weaponItem;
        set => weaponItem = value;
    }

}
