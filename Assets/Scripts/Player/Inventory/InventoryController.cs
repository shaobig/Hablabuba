using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, WeaponSelector, IndexSetter
{
    [SerializeField]
    private AllWeaponInventoryFiller allWeaponInventoryFiller;
    private List<WeaponItem> weaponItemList;
    private int currentIndex;

    public void Init()
    {
        weaponItemList = allWeaponInventoryFiller.FillInventory();
    }

    public WeaponItem SelectWeapon()
    {
        return weaponItemList[currentIndex];
    }

    public void SetIndex(int index)
    {
        currentIndex = index;
    }

    public List<WeaponItem> WeaponItemList => weaponItemList;
    
}
