using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryGridFiller : MonoBehaviour, GridFiller
{
    [SerializeField]
    private InitWeaponSlotControllerGameObjectFactory weaponSlotControllerGameObjectFactory;
    [SerializeField]
    private GameObject slotPrefab;
    private RectTransform panel;

    public void Init(RectTransform panel)
    {
        this.panel = panel;
    }

    public List<WeaponSlotController> FillGrid(List<WeaponItem> weaponList)
    {
        return weaponList.Select(weapon =>
        {
            weaponSlotControllerGameObjectFactory.WeaponItem = weapon;
            return weaponSlotControllerGameObjectFactory.Create(slotPrefab, panel);
        })
        .ToList();
    }

}
