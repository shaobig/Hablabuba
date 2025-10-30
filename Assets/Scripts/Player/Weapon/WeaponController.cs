using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, FireController,
    OnWeaponChangeAngleKeyPressedListener
{
    [SerializeField]
    private FireControllerGameObjectFactory fireControllerGameObjectFactory;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private WeaponTurner weaponTurner;
    [SerializeField]
    private Transform holdPoint;
    private FireController fireController;
    private WeaponItem weaponItem;
    private bool isWeaponHeld;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        fireControllerGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onAmmoCollideListener, onSetCameraOnShotPlayerListener);
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
        fireController = fireControllerGameObjectFactory.Create(weaponItem.Prefab, holdPoint);
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

    public bool IsWeaponHeld => isWeaponHeld;

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            fireControllerGameObjectFactory.WeaponItem = value;
        }
    }

}
