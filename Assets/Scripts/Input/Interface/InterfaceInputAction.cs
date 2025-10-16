using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InterfaceInputAction", menuName = "Game/Interface/InterfaceInputAction")]
public class InterfaceInputAction : ScriptableObject
{
    private const string INTERFACE_INPUT_MAP = "Interface";
    private const string OPEN_INVENTORY_INPUT_ACTION = "OpenInventory";
    private const string SWITCH_WEAPON_INPUT_ACTION = "SwitchWeapon";
    private const string SELECT_WEAPON_INPUT_ACTION = "SelectWeapon";

    private InputAction openInventoryAction;
    private InputAction selectWeaponAction;
    private InputAction switchWeaponAction;

    public void Init(InputActionAsset inputActionAsset)
    {
        var map = inputActionAsset.FindActionMap(INTERFACE_INPUT_MAP);

        openInventoryAction = map.FindAction(OPEN_INVENTORY_INPUT_ACTION);
        switchWeaponAction = map.FindAction(SWITCH_WEAPON_INPUT_ACTION);
        selectWeaponAction = map.FindAction(SELECT_WEAPON_INPUT_ACTION);

        openInventoryAction.Enable();
        switchWeaponAction.Enable();
        selectWeaponAction.Enable();
    }

    public InputAction OpenInventoryAction => openInventoryAction;
    public InputAction SwitchWeaponAction => switchWeaponAction;
    public InputAction SelectWeaponAction => selectWeaponAction;
    
}
