using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceInputController : MonoBehaviour
{
    [SerializeField]
    private InterfaceInputAction interfaceInputAction;

    public void Init(
        InputActionAsset inputActionAsset,
        OnInventoryToggleListener onInventoryToggleListener,
        OnWeaponSwitchListener onWeaponSwitchListener,
        OnWeaponSelectListener onWeaponSelectListener
        )
    {
        interfaceInputAction.Init(inputActionAsset);

        interfaceInputAction.OpenInventoryAction.performed += context => onInventoryToggleListener.OnInventoryToggle();
        interfaceInputAction.SwitchWeaponAction.performed += context => onWeaponSwitchListener.OnWeaponSwitch(context.ReadValue<Vector2>());
        interfaceInputAction.SelectWeaponAction.performed += context => onWeaponSelectListener.OnWeaponSelect();
    }
    
}
