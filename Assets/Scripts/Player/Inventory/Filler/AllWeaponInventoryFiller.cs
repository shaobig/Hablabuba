using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllWeaponInventoryFiller : MonoBehaviour, InventoryFiller
{
    private const int DEFAULT_AMOUNT = 1;

    [SerializeField]
    private WeaponDatabaseReader weaponDatabaseReader;

    public List<WeaponItem> FillInventory()
    {
        return weaponDatabaseReader.ReadDatabase()
            .Select(prefab => new WeaponItem(prefab.Weapon, prefab.Sprite, prefab.Prefab, DEFAULT_AMOUNT))
            .ToList();
    }

}
