using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputAction", menuName = "Game/Input/Player")]
public class PlayerInputAction : ScriptableObject
{
    private const string INPUT_MAP = "Player";
    private const string MOVE_ACTION = "Move";

    private InputAction moveAction;

    public void Init(InputActionAsset inputActionAsset)
    {
        var map = inputActionAsset.FindActionMap(INPUT_MAP);

        moveAction = map.FindAction(MOVE_ACTION);
        moveAction.Enable();
    }

    public InputAction MoveAction => moveAction;

}
