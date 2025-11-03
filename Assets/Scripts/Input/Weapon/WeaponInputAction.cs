using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "WeaponInputAction", menuName = "Game/Input/Weapon")]
public class WeaponInputAction : ScriptableObject
{
    private const string INPUT_MAP = "Weapon";

    private const string AIM_ACTION = "Aim";
    private const string FIRE_ACTION = "Fire";
    private const string CHANGE_ANGLE_ACTION = "ChangeAngle";

    private InputAction aimAction;
    private InputAction fireAction;
    private InputAction changeAngleAction;

    public void Init(InputActionAsset inputActionAsset)
    {
        var map = inputActionAsset.FindActionMap(INPUT_MAP);

        aimAction = map.FindAction(AIM_ACTION);
        fireAction = map.FindAction(FIRE_ACTION);
        changeAngleAction = map.FindAction(CHANGE_ANGLE_ACTION);

        aimAction.Enable();
        fireAction.Enable();
        changeAngleAction.Enable();
    }

    public InputAction AimAction => aimAction;
    public InputAction FireAction => fireAction;
    public InputAction ChangeAngleAction => changeAngleAction;

}
