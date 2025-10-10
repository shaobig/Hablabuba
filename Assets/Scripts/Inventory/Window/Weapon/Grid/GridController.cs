using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour, Activator, Deactivator, WeaponSwitcher, IndexReseter
{
    [SerializeField]
    private InventoryGridFiller inventoryGridFiller;
    [SerializeField]
    private WeaponSlotRemover weaponSlotRemover;
    [SerializeField]
    private InventoryGridSizeMaker inventoryGridSizeMaker;
    [SerializeField]
    private GridWeaponSelector gridWeaponSelector;
    [SerializeField]
    private int columnSize = 5;
    private List<WeaponSlotController> weaponSlotList;
    private List<WeaponItem> weaponList;

    public void Init(RectTransform weaponPanel, GridLayoutGroup gridLayoutGroup, List<WeaponItem> weaponList)
    {
        this.weaponList = weaponList;

        inventoryGridFiller.Init(weaponPanel);
        inventoryGridSizeMaker.Init(weaponPanel, gridLayoutGroup, columnSize);
        gridWeaponSelector.Init(columnSize);
    }

    public void Activate()
    {
        enabled = true;

        weaponSlotList = inventoryGridFiller.FillGrid(weaponList);
        inventoryGridSizeMaker.MakeGridSize();

        gridWeaponSelector.WeaponSlotList = weaponSlotList;
        gridWeaponSelector.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        
        weaponSlotRemover.Remove(weaponSlotList);
        gridWeaponSelector.Deactivate();
    }

    public int SwitchWeapon(SwitchDirection direction)
    {
        return gridWeaponSelector.SwitchWeapon(direction);
    }

    public int ResetIndex()
    {
        return gridWeaponSelector.ResetIndex();
    }

}
