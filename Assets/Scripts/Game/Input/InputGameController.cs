using UnityEngine;
using UnityEngine.InputSystem;

public class InputGameController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputGameController playerInputGameController;
    [SerializeField]
    private InterfaceInputController interfaceInputController;
    [SerializeField]
    private WeaponInputController weaponInputController;
    [SerializeField]
    private InputActionAsset inputActionAsset;

    public void Init(
        OnMoveKeyPressedListener onMoveKeyPressedListener,
        OnInventoryOpenKeyPressedListener onInventoryOpenKeyPressedListener,
        OnWeaponSwitchKeyPressedListener onWeaponSwitchKeyPressedListener,
        OnWeaponChangeAngleKeyPressedListener onWeaponChangeAngleKeyPressedListener,
        OnAimKeyPressedListener onAimKeyPressedListener,
        OnWeaponSelectKeyPressedListener onWeaponSelectKeyPressedListener,
        OnFireKeyPressedListener onFireKeyPressedListener,
        OnLongFireKeyPressedListener onLongFireKeyPressedListener,
        OnStopFireKeyPressedListener onStopFireKeyPressedListener)
    {
        playerInputGameController.Init(inputActionAsset, onMoveKeyPressedListener);
        interfaceInputController.Init(inputActionAsset, onInventoryOpenKeyPressedListener, onWeaponSwitchKeyPressedListener, onWeaponSelectKeyPressedListener);
        weaponInputController.Init(inputActionAsset, onWeaponChangeAngleKeyPressedListener, onAimKeyPressedListener, onFireKeyPressedListener, onLongFireKeyPressedListener, onStopFireKeyPressedListener);
    }

}
