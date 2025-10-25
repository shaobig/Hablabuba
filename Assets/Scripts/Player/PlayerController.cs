using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Activator, Deactivator, DisplayRefresher,
    WeaponHolder, WeaponHider,
    OnMoveKeyPressedListener, OnWeaponChangeAngleKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener,
    OnWeaponSelectKeyPressedListener,
    OnDamagePlayerListener
{
    [SerializeField]
    private DisplayController displayController;
    [SerializeField]
    private MovementController movementController;
    [SerializeField]
    private InventoryController inventoryController;
    [SerializeField]
    private WeaponController weaponController;
    [SerializeField]
    private HealthController healthController;
    [SerializeField]
    private BodyController bodyController;
    private Player player;
    private OnSelectWeaponListener onSeleectWeaponListener;

    public void Init(
        OnSelectWeaponListener onSeleectWeaponListener,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        this.onSeleectWeaponListener = onSeleectWeaponListener;

        displayController.Init(player, bodyController.Renderer.material.color);
        displayController.Paint();

        movementController.Init(GetComponent<Rigidbody>());
        movementController.Deactivate();

        inventoryController.Init();

        healthController.Init(player.Health);

        weaponController.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onAmmoCollideListener, onSetCameraOnShotPlayerListener);
    }

    public void OnDamagePlayer(int damage)
    {
        healthController.OnDamagePlayer(damage);
        displayController.SetHealthText(healthController.Health);
    }

    public void Activate()
    {
        enabled = true;

        movementController.Activate();
        weaponController.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        movementController.Deactivate();
    }

    public void HoldWeapon()
    {
        weaponController.WeaponItem = inventoryController.SelectWeapon();
        weaponController.HoldWeapon();
    }

    public void OnWeaponChangeAngleKeyPressed(float scrollInput)
    {
        weaponController.OnWeaponChangeAngleKeyPressed(scrollInput);
    }

    public void HideWeapon()
    {
        weaponController.HideWeapon();
    }

    public void RefreshDisplay()
    {
        displayController.RefreshDisplay();
    }

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        movementController.OnMoveKeyPressed(moveInput);

        if (Vector2.zero.Equals(moveInput))
        {
            displayController.EnableText();
        }
        else
        {
            displayController.DisableText();
        }
    }

    public void OnWeaponSelectKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.HideWeapon();
        }

        var selectedWeapon = inventoryController.SelectWeapon();
        weaponController.WeaponItem = selectedWeapon;

        weaponController.HoldWeapon();
        onSeleectWeaponListener.OnSelectWeapon(selectedWeapon.Weapon.Type);
    }

    public void OnFireKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Fire(FireAction.FIRE);
        }
    }

    public void OnLongFireKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Fire(FireAction.LONG_FIRE);
        }
    }

    public void OnStopFireKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Fire(FireAction.STOP);

            movementController.Deactivate();
            weaponController.Deactivate();
        }

    }

    public Transform Camera
    {
        set => displayController.Camera = value;
    }

    public Player Player
    {
        get => player;
        set => player = value;
    }

    public bool IsDead => healthController.IsDead;
    public List<WeaponItem> WeaponItemList => inventoryController.WeaponItemList;

    public int CurrentWeaponIndex
    {
        set => inventoryController.CurrentWeaponIndex = value;
    }

    public OnSelectWeaponListener OnSeleectWeaponListener
    {
        set => onSeleectWeaponListener = value;
    }

}
