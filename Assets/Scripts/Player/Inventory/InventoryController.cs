using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, WeaponSelector
{
    [SerializeField]
    private AllWeaponInventoryFiller allWeaponInventoryFiller;
    private List<WeaponItem> weaponItemList;
    private int currentWeaponIndex;

    public void Init()
    {
        weaponItemList = allWeaponInventoryFiller.FillInventory();
    }

    public WeaponItem SelectWeapon()
    {
        return weaponItemList[currentWeaponIndex];
    }

    public List<WeaponItem> WeaponItemList => weaponItemList;

    public int CurrentWeaponIndex
    {
        set => currentWeaponIndex = value;
    }
    
}
