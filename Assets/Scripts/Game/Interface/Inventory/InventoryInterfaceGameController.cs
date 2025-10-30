using System.Collections.Generic;
using UnityEngine;

public class InventoryInterfaceGameController : MonoBehaviour, Deactivator, WindowFiller,
    OnInventoryOpenKeyPressedListener, OnWeaponSwitchKeyPressedListener
{
    [SerializeField]
    private WindowControllerGameObjectFactory windowControllerGameObjectFactory;
    [SerializeField]
    private GameObject inventoryPrefab;
    private WindowController windowController;
    private int currentIndex;
    private bool isInventoryOpened;

    public void Init(Transform canvas)
    {
        windowController = windowControllerGameObjectFactory.Create(inventoryPrefab, canvas);
        windowController.gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        windowController.Deactivate();
        currentIndex = windowController.ResetIndex();
    }

    public void FillWindow(List<WeaponItem> weaponItemList)
    {
        windowController.Init(weaponItemList);
        windowController.Activate();
    }

    public void OnInventoryOpenKeyPressed()
    { 
        isInventoryOpened = !windowController.gameObject.activeSelf;
        windowController.gameObject.SetActive(isInventoryOpened);
    }

    public void OnWeaponSwitchKeyPressed(Vector2 switchInput)
    {
        if (Vector2.up.Equals(switchInput))
        {
            currentIndex = windowController.SwitchWeapon(SwitchDirection.UP);
        }
        else if (Vector2.down.Equals(switchInput))
        {
            currentIndex = windowController.SwitchWeapon(SwitchDirection.DOWN);
        }
        else if (Vector2.left.Equals(switchInput))
        {
            currentIndex = windowController.SwitchWeapon(SwitchDirection.LEFT);
        }
        else if (Vector2.right.Equals(switchInput))
        {
            currentIndex = windowController.SwitchWeapon(SwitchDirection.RIGHT);
        }
    }

    public int CurrentIndex => currentIndex;

}
