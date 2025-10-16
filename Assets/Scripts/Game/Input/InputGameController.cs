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
        OnInventoryToggleListener onInventoryToggleListener,
        OnWeaponSwitchListener onWeaponSwitchListener,
        OnWeaponChangeAngleListener onWeaponChangeAngleListener,
        OnWeaponSelectListener onWeaponSelectListener,
        OnPlayerMoveListener onPlayerMoveListener,
        OnPlayerFireListener onPlayerFireListener)
    {
        playerInputGameController.Init(inputActionAsset, onPlayerMoveListener, onWeaponChangeAngleListener, onPlayerFireListener);
        interfaceInputController.Init(inputActionAsset, onInventoryToggleListener, onWeaponSwitchListener, onWeaponSelectListener);

    }

}
