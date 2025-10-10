using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour, Activator, Deactivator, InventoryOpener, InventoryCloser, WeaponSwitcher, IndexReseter
{
    [SerializeField]
    private WeaponPanelController weaponPanelController;
    [SerializeField]
    private SelectPanelController selectPanelController;
    private List<WeaponItem> weaponList;

    public void Init(List<WeaponItem> weaponList)
    {
        this.weaponList = weaponList;

        weaponPanelController.Init(weaponList);
        selectPanelController.Init(weaponList[0].Weapon.Name);

        gameObject.SetActive(false);
    }

    public void Activate()
    {
        enabled = true;

        weaponPanelController.Activate();
        selectPanelController.SetWeaponText(weaponList[0].Weapon.Name);
    }

    public void Deactivate()
    {
        enabled = false;

        weaponPanelController.Deactivate();
    }

    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }

    public int SwitchWeapon(SwitchDirection direction)
    {
        int weaponIndex = weaponPanelController.SwitchWeapon(direction);
        selectPanelController.SetWeaponText(weaponList[weaponIndex].Weapon.Name);

        return weaponIndex;
    }

    public int ResetIndex()
    {
        return weaponPanelController.ResetIndex();
    }

}
