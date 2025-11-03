using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputGameController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputAction playerInputAction;

    public void Init(InputActionAsset inputActionAsset, OnMoveKeyPressedListener onMoveKeyPressedListener)
    {
        playerInputAction.Init(inputActionAsset);

        playerInputAction.MoveAction.performed += context => onMoveKeyPressedListener.OnMoveKeyPressed(context.ReadValue<Vector2>());
        playerInputAction.MoveAction.canceled += context => onMoveKeyPressedListener.OnMoveKeyPressed(Vector2.zero);
    }

}
