using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputGameController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputAction playerInputAction;

    public void Init(
        InputActionAsset inputActionAsset,
        OnMoveKeyPressedListener onMoveKeyPressedListener,
        OnWeaponChangeAngleKeyPressedListener onChangeWeaponAngleListener,
        OnFireKeyPressedListener onFireKeyPressedListener,
        OnLongFireKeyPressedListener onLongFireKeyPressedListener,
        OnStopFireKeyPressedListener onStopFireKeyPressedListener
        )
    {
        playerInputAction.Init(inputActionAsset);

        playerInputAction.MoveAction.performed += context => onMoveKeyPressedListener.OnMoveKeyPressed(context.ReadValue<Vector2>());
        playerInputAction.MoveAction.canceled += context => onMoveKeyPressedListener.OnMoveKeyPressed(Vector2.zero);

        playerInputAction.FireAction.started += context => onFireKeyPressedListener.OnFireKeyPressed();
        playerInputAction.FireAction.performed += context => onLongFireKeyPressedListener.OnLongFireKeyPressed();
        playerInputAction.FireAction.canceled += context => onStopFireKeyPressedListener.OnStopFireKeyPressed();

        playerInputAction.ChangeWeaponAngleAction.performed += context => onChangeWeaponAngleListener.OnWeaponChangeAngleKeyPressed(context.ReadValue<float>());
    }

}
