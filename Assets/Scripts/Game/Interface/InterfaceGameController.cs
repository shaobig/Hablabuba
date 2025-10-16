using System.Collections.Generic;
using UnityEngine;

public class InterfaceGameController : MonoBehaviour, Deactivator, WindowFiller,
    OnInventoryToggleListener, OnWeaponSwitchListener
{
    [SerializeField]
    private InventoryInterfaceGameController inventoryInterfaceGameController;
    [SerializeField]
    private Canvas canvas;

    public void Init()
    {
        inventoryInterfaceGameController.Init(canvas.transform);
    }

    public void Deactivate()
    {
        inventoryInterfaceGameController.Deactivate();
    }

    public void FillWindow(List<WeaponItem> weaponItemList)
    {
        inventoryInterfaceGameController.FillWindow(weaponItemList);
    }

    public void OnInventoryToggle()
    {
        inventoryInterfaceGameController.OnInventoryToggle();
    }

    public void OnWeaponSwitch(Vector2 switchInput)
    {
        inventoryInterfaceGameController.OnWeaponSwitch(switchInput);
    }

    public int CurrentWeaponIndex => inventoryInterfaceGameController.CurrentIndex;

}
