using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanelController : MonoBehaviour, WeaponSwitcher, IndexReseter
{
    [SerializeField]
    private GridController gridController;
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;
    [SerializeField]
    private RectTransform weaponPanel;

    public void Init(List<WeaponItem> weaponList)
    {
        gridController.Init(weaponPanel, gridLayoutGroup, weaponList);
    }

    public void Activate()
    {
        enabled = true;
        gridController.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        gridController.Deactivate();
    }

    public int SwitchWeapon(SwitchDirection direction)
    {
        return gridController.SwitchWeapon(direction);
    }

    public int ResetIndex()
    {
        return gridController.ResetIndex();
    }

}
