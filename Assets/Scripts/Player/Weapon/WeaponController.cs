using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, FireController,
    OnWeaponChangeAngleKeyPressedListener
{
    [SerializeField]
    private FireControllerGameObjectFactory fireControllerGameObjectFactory;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private AngleDefinerWeaponInputTurner weaponInputTurner;
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
        weaponInputTurner.Init(holdPoint);
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
        weaponInputTurner.Activate();

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
        weaponInputTurner.Turn(scrollInput);
    }

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            fireControllerGameObjectFactory.WeaponType = value.Weapon.Type;
            weaponInputTurner.WeaponType = value.Weapon.Type;
        }
    }

    public bool IsWeaponHeld => isWeaponHeld;

}
