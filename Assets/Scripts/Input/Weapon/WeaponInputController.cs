using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInputController : MonoBehaviour
{
    [SerializeField]
    private WeaponInputAction weaponInputAction;

    public void Init(
        InputActionAsset inputActionAsset,
        OnWeaponChangeAngleKeyPressedListener onWeaponChangeAngleKeyPressedListener,
        OnAimKeyPressedListener onAimKeyPressedListener,
        OnAimKeyReleasedListener onAimKeyReleasedListener,
        OnFireKeyPressedListener onFireKeyPressedListener,
        OnLongFireKeyPressedListener onLongFireKeyPressedListener,
        OnStopFireKeyPressedListener onStopFireKeyPressedListener)
    {
        weaponInputAction.Init(inputActionAsset);

        weaponInputAction.ChangeAngleAction.performed += context => onWeaponChangeAngleKeyPressedListener.OnWeaponChangeAngleKeyPressed(context.ReadValue<float>());
        weaponInputAction.AimAction.performed += context => onAimKeyPressedListener.OnAimKeyPressed();
        weaponInputAction.AimAction.canceled += context => onAimKeyReleasedListener.OnAimKeyReleased();

        weaponInputAction.FireAction.started += context => onFireKeyPressedListener.OnFireKeyPressed();
        weaponInputAction.FireAction.performed += context => onLongFireKeyPressedListener.OnLongFireKeyPressed();
        weaponInputAction.FireAction.canceled += context => onStopFireKeyPressedListener.OnStopFireKeyPressed();
    }

}
