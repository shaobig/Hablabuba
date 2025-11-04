using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, ShootController, AimTaker,
    OnWeaponChangeAngleKeyPressedListener
{
    [SerializeField]
    private ShootControllerGameObjectFactory shooterGameObjectFactory;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private AngleDefinerWeaponInputTurner weaponInputTurner;
    [SerializeField]
    private Transform holdPoint;
    private AimShootController shootController;
    private WeaponItem weaponItem;
    private bool isWeaponHeld;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnNextStepPreparedListener onAmmoCollideListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener)
    {
        shooterGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onAimTakenListener, onFireListener, onAmmoShotListener, onAmmoCollideListener, onSetCameraOnObjectListener);
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
        shootController = shooterGameObjectFactory.Create(weaponItem.Prefab, holdPoint);
        weaponInputTurner.Activate();

        isWeaponHeld = true;
    }

    public void HideWeapon()
    {
        gameObjectRemover.Remove(holdPoint.GetChild(0).gameObject);
        isWeaponHeld = false;
    }

    public void Shoot(ShootAction fireAction)
    {
        if (enabled)
        {
            shootController.Shoot(fireAction);
        }
    }

    public void TakeAim()
    {
        if (enabled)
        {
            shootController.TakeAim();
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
            shooterGameObjectFactory.WeaponType = value.Weapon.Type;
            weaponInputTurner.WeaponType = value.Weapon.Type;
        }
    }

    public bool IsWeaponHeld => isWeaponHeld;

}
