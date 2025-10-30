using System.Collections.Generic;
using UnityEngine;

public class InterfaceGameController : MonoBehaviour, Deactivator, WindowFiller, IndexReseter,
    OnInventoryOpenKeyPressedListener, OnWeaponSwitchKeyPressedListener,
    OnSelectWeaponListener, OnFireListener, OnWeaponProgressBarChangeValueListener
{
    [SerializeField]
    private InventoryInterfaceGameController inventoryInterfaceGameController;
    [SerializeField]
    private WeaponProgressBarGameController weaponProgressBarGameController;
    [SerializeField]
    private Canvas canvas;

    public void Init()
    {
        inventoryInterfaceGameController.Init(canvas.transform);
        weaponProgressBarGameController.Init(canvas.transform);
    }

    public void Deactivate()
    {
        inventoryInterfaceGameController.Deactivate();
        weaponProgressBarGameController.Deactivate();
    }

    public void FillWindow(List<WeaponItem> weaponItemList)
    {
        inventoryInterfaceGameController.FillWindow(weaponItemList);
    }

    public int ResetIndex()
    {
        return inventoryInterfaceGameController.ResetIndex();
    }

    public void OnInventoryOpenKeyPressed()
    {
        inventoryInterfaceGameController.OnInventoryOpenKeyPressed();
    }

    public void OnWeaponSwitchKeyPressed(Vector2 switchInput)
    {
        inventoryInterfaceGameController.OnWeaponSwitchKeyPressed(switchInput);
    }

    public void OnSelectWeapon(WeaponType weaponType)
    {
        if (WeaponType.BAZOOKA.Equals(weaponType) || WeaponType.GRENADE.Equals(weaponType))
        {
            weaponProgressBarGameController.Activate();
        }
    }

    public void OnFire(WeaponType weaponType)
    {
        if (WeaponType.BAZOOKA.Equals(weaponType) || WeaponType.GRENADE.Equals(weaponType))
        {
            weaponProgressBarGameController.Deactivate();
        }

        inventoryInterfaceGameController.Deactivate();
    }

    public void OnWeaponProgressBarChangeValue(float value)
    {
        weaponProgressBarGameController.OnWeaponProgressBarChangeValue(value);
    }

    public int CurrentWeaponIndex => inventoryInterfaceGameController.CurrentIndex;

}
