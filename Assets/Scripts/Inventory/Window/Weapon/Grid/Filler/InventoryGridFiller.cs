using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryGridFiller : MonoBehaviour, GridFiller
{
    [SerializeField]
    private InitWeaponSlotControllerCreator weaponSlotControllerCreator;
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
            weaponSlotControllerCreator.WeaponItem = weapon;
            return weaponSlotControllerCreator.Create(slotPrefab, panel);
        })
        .ToList();
    }

}
