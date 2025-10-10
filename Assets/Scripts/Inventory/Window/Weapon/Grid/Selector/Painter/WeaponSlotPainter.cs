using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotPainter : MonoBehaviour, Activator, Deactivator, Painter
{
    [SerializeField]
    private Color defaultColour;
    [SerializeField]
    private Color selectedColour;
    private List<WeaponSlotController> weaponSlotList;
    private int currentIndex;
    private int lastIndex;

    public void Activate()
    {
        weaponSlotList[currentIndex].SetBackgroundColour(selectedColour);
    }

    public void Deactivate()
    {
        currentIndex = 0;
        lastIndex = 0;
    }

    public void Paint()
    {  
        weaponSlotList[lastIndex].SetBackgroundColour(defaultColour);
        weaponSlotList[currentIndex].SetBackgroundColour(selectedColour);

        lastIndex = currentIndex;
    }

    public int CurrentIndex
    {
        get => currentIndex;
        set => currentIndex = value;
    }

    public List<WeaponSlotController> WeaponSlotList
    {
        get => weaponSlotList;
        set => weaponSlotList = value;
    }

}
