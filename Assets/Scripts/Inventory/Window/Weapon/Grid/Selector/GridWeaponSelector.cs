using System.Collections.Generic;
using UnityEngine;

public class GridWeaponSelector : MonoBehaviour, Activator, Deactivator, WeaponSwitcher, IndexReseter
{
    [SerializeField]
    private WeaponSlotPainter weaponSlotPainter;
    private List<WeaponSlotController> weaponSlotList;
    private int columnSize;
    private int currentIndex;

    public void Init(int columnSize)
    {
        this.columnSize = columnSize;
    }

    public void Activate()
    {
        weaponSlotPainter.Activate();
    }

    public void Deactivate()
    {
        weaponSlotPainter.Deactivate();
    }

    public int SwitchWeapon(SwitchDirection direction)
    {
        if (SwitchDirection.UP.Equals(direction) && currentIndex > columnSize)
        {
            currentIndex -= columnSize;
        }
        else if (SwitchDirection.DOWN.Equals(direction) && currentIndex < weaponSlotList.Count - columnSize)
        {
            currentIndex += columnSize;
        }
        else if (SwitchDirection.LEFT.Equals(direction) && currentIndex > 0)
        {
            currentIndex -= 1;
        }
        else if (SwitchDirection.RIGHT.Equals(direction) && currentIndex < weaponSlotList.Count - 1)
        {
            currentIndex += 1;
        }

        weaponSlotPainter.CurrentIndex = currentIndex;
        weaponSlotPainter.Paint();

        return currentIndex;
    }

    public int ResetIndex()
    {
        currentIndex = 0;
        return currentIndex;
    }

    public List<WeaponSlotController> WeaponSlotList
    {
        get => weaponSlotList;
        set
        {
            weaponSlotList = value;
            weaponSlotPainter.WeaponSlotList = value;
        }
    }

}
