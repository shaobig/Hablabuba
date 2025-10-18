using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceInputController : MonoBehaviour
{
    [SerializeField]
    private InterfaceInputAction interfaceInputAction;

    public void Init(
        InputActionAsset inputActionAsset,
        OnInventoryOpenKeyPressedListener onInventoryOpenKeyPressedListener,
        OnWeaponSwitchKeyPressedListener onWeaponSwitchKeyPressedListener,
        OnWeaponSelectKeyPressedListener onWeaponSelectKeyPressedListener
        )
    {
        interfaceInputAction.Init(inputActionAsset);

        interfaceInputAction.OpenInventoryAction.performed += context => onInventoryOpenKeyPressedListener.OnInventoryOpenKeyPressed();
        interfaceInputAction.SwitchWeaponAction.performed += context => onWeaponSwitchKeyPressedListener.OnWeaponSwitchKeyPressed(context.ReadValue<Vector2>());
        interfaceInputAction.SelectWeaponAction.performed += context => onWeaponSelectKeyPressedListener.OnWeaponSelectKeyPressed();
    }
    
}
