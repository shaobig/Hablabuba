using UnityEngine;
using UnityEngine.InputSystem;

public class InputGameController : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionAsset;
    [SerializeField]
    private PlayerInputGameController playerInputGameController;
    [SerializeField]
    private InterfaceInputController interfaceInputController;

    public void Init(
        OnMoveKeyPressedListener onMoveKeyPressedListener,
        OnFireKeyPressedListener onFireKeyPressedListener,
        OnLongFireKeyPressedListener onLongFireKeyPressedListener,
        OnStopFireKeyPressedListener onStopFireKeyPressedListener,
        OnInventoryOpenKeyPressedListener onInventoryOpenKeyPressedListener,
        OnWeaponSwitchKeyPressedListener onWeaponSwitchKeyPressedListener,
        OnWeaponChangeAngleKeyPressedListener onWeaponChangeAngleKeyPressedListener,
        OnWeaponSelectKeyPressedListener onWeaponSelectKeyPressedListener)
    {
        playerInputGameController.Init(inputActionAsset, onMoveKeyPressedListener, onWeaponChangeAngleKeyPressedListener, onFireKeyPressedListener, onLongFireKeyPressedListener, onStopFireKeyPressedListener);
        interfaceInputController.Init(inputActionAsset, onInventoryOpenKeyPressedListener, onWeaponSwitchKeyPressedListener, onWeaponSelectKeyPressedListener);

    }

}
