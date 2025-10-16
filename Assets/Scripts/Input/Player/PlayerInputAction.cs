using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputAction", menuName = "Game/Player/PlayerInputAction")]
public class PlayerInputAction : ScriptableObject
{
    private const string PLAYER_INPUT_MAP = "Player";
    private const string MOVE_INPUT_ACTION = "Move";
    private const string FIRE_INPUT_ACTION = "Fire";
    private const string CHANGE_WEAPON_ANGLE_INPUT_ACTION = "ChangeWeaponAngle";

    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction changeWeaponAngleAction;

    public void Init(InputActionAsset inputActionAsset)
    {
        var map = inputActionAsset.FindActionMap(PLAYER_INPUT_MAP);

        moveAction = map.FindAction(MOVE_INPUT_ACTION);
        fireAction = map.FindAction(FIRE_INPUT_ACTION);
        changeWeaponAngleAction = map.FindAction(CHANGE_WEAPON_ANGLE_INPUT_ACTION);

        moveAction.Enable();
        fireAction.Enable();
        changeWeaponAngleAction.Enable();
    }

    public InputAction MoveAction => moveAction;
    public InputAction FireAction => fireAction;
    public InputAction ChangeWeaponAngleAction => changeWeaponAngleAction;

}
