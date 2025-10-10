using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, Activator, Deactivator, InventoryOpener, InventoryCloser, WeaponSelector
{
    [SerializeField]
    private AllWeaponInventoryFiller allWeaponInventoryFiller;
    private WindowController windowController;
    private List<WeaponItem> weaponList;
    private int currentIndex;
    private bool isOpened;

    public void Init(WindowController windowController)
    {
        this.windowController = windowController;

        weaponList = allWeaponInventoryFiller.FillInventory();
        windowController.Init(weaponList);
    }

    void Update()
    {
        if (isOpened)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentIndex = windowController.SwitchWeapon(SwitchDirection.UP);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentIndex = windowController.SwitchWeapon(SwitchDirection.DOWN);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentIndex = windowController.SwitchWeapon(SwitchDirection.LEFT);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentIndex = windowController.SwitchWeapon(SwitchDirection.RIGHT);
            }
        }
    }

    public void Activate()
    {
        enabled = true;
        windowController.Activate();
    }

    public void Deactivate()
    {
        enabled = false;

        currentIndex = 0;
        windowController.Deactivate();
    }

    public void OpenInventory()
    {
        windowController.OpenInventory();
        isOpened = true;
    }

    public void CloseInventory()
    {
        windowController.CloseInventory();
        isOpened = false;
    }

    public WeaponItem SelectWeapon()
    {
        return weaponList[currentIndex];
    }

    public bool IsOpened
    {
        get => isOpened;
    }

}
