using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, FireController,
    OnWeaponChangeAngleKeyPressedListener, OnStopFireKeyPressedListener
{
    [SerializeField]
    private FireControllerCreator fireControllerCreator;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private WeaponTurner weaponTurner;
    [SerializeField]
    private Transform holdPoint;
    private FireController fireController;
    private WeaponItem weaponItem;
    private OnStopFireListener onStopFireListener;
    private bool isWeaponHeld;

    public void Init(
        OnStopFireListener onStopFireListener,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        this.onStopFireListener = onStopFireListener;
        
        fireControllerCreator.Init(onWeaponProgressBarChangeValueListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
        weaponTurner.Init(holdPoint);
    }

    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

    public void HoldWeapon()
    {
        fireController = fireControllerCreator.Create(weaponItem.Prefab, holdPoint);
        isWeaponHeld = true;
    }

    public void HideWeapon()
    {
        gameObjectRemover.Remove(holdPoint.GetChild(0).gameObject);
        isWeaponHeld = false;
    }

    public void Fire(FireAction fireAction)
    {
        if (enabled)
        {
            fireController.Fire(fireAction);
        }
    }

    public void OnWeaponChangeAngleKeyPressed(float scrollInput)
    {
        weaponTurner.ScrollInput = scrollInput;
        weaponTurner.Turn();
    }

    public void OnStopFireKeyPressed()
    {
        if (enabled)
        {
            onStopFireListener.OnStopFire(weaponItem.Weapon.WeaponType);
        }
    }

    public bool IsWeaponHeld => isWeaponHeld;

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            fireControllerCreator.WeaponItem = value;
        }
    }

}
