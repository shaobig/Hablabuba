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
        OnPlayerMoveListener onPlayerMoveListener,
        OnPlayerFireListener onPlayerFireListener,
        OnPlayerStopFireListener onPlayerStopFireListener,
        OnInventoryToggleListener onInventoryToggleListener,
        OnWeaponSwitchListener onWeaponSwitchListener,
        OnWeaponChangeAngleListener onWeaponChangeAngleListener,
        OnWeaponSelectListener onWeaponSelectListener)
    {
        playerInputGameController.Init(inputActionAsset, onPlayerMoveListener, onWeaponChangeAngleListener, onPlayerFireListener, onPlayerStopFireListener);
        interfaceInputController.Init(inputActionAsset, onInventoryToggleListener, onWeaponSwitchListener, onWeaponSelectListener);

    }

}
