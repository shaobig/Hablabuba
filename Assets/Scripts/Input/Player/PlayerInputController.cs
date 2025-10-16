using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputGameController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputAction playerInputAction;

    public void Init(InputActionAsset inputActionAsset,
        OnPlayerMoveListener onPlayerMoveListener,
        OnWeaponChangeAngleListener onChangeWeaponAngleListener,
        OnPlayerFireListener onPlayerFireListener)
    {
        playerInputAction.Init(inputActionAsset);

        playerInputAction.MoveAction.performed += context => onPlayerMoveListener.OnPlayerMove(context.ReadValue<Vector2>());
        playerInputAction.MoveAction.canceled += context => onPlayerMoveListener.OnPlayerMove(Vector2.zero);

        playerInputAction.FireAction.started += context => onPlayerFireListener.OnPlayerFire();
        playerInputAction.FireAction.performed += context => onPlayerFireListener.OnPlayerFire();

        playerInputAction.ChangeWeaponAngleAction.performed += context => onChangeWeaponAngleListener.OnWeaponChangeAngle(context.ReadValue<float>());
    }

}
