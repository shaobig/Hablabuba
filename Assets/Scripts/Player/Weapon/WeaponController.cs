using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, FireController,
    OnWeaponChangeAngleListener
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
    private bool isWeaponHeld;

    public void Init(OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        fireControllerCreator.Init(onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
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

    public void OnWeaponChangeAngle(float scrollInput)
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
            fireControllerCreator.WeaponItem = value;
        }
    }

}
