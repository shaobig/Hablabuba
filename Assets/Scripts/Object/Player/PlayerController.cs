using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Activator, Deactivator, DisplayRefresher,
    WeaponHolder, WeaponHider, IndexSetter,
    DamageTaker,
    OnMoveKeyPressedListener,
    OnWeaponSelectKeyPressedListener,
    OnAimKeyPressedListener, OnWeaponChangeAngleKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener
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
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener)
    {
        this.onSeleectWeaponListener = onSeleectWeaponListener;

        displayController.Init(player.name, healthController.MaxHealth, bodyController.Renderer.material.color);
        displayController.Paint();

        movementController.Init(GetComponent<Rigidbody>());
        movementController.Deactivate();

        inventoryController.Init();

        weaponController.Init(onWeaponProgressBarChangeValueListener, onAimTakenListener, onFireListener, onAmmoShotListener, onAmmoCollideListener, onSetCameraOnObjectListener);

        healthController.Init();
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

    public void SetIndex(int index)
    {
        inventoryController.SetIndex(index);
    }

    public void TakeDamage(int damage)
    {
        healthController.TakeDamage(damage);
        displayController.SetHealthText(healthController.CurrentHealth);
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

    public void OnAimKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.TakeAim();
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
            weaponController.Shoot(ShootAction.FIRE);
        }
    }

    public void OnLongFireKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Shoot(ShootAction.LONG_FIRE);
        }
    }

    public void OnStopFireKeyPressed()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Shoot(ShootAction.STOP);

            movementController.Deactivate();
            weaponController.Deactivate();
        }

    }

    public bool IsDead => healthController.IsDead;

    public List<WeaponItem> WeaponItemList => inventoryController.WeaponItemList;

    public Player Player
    {
        set => player = value;
    }

    public Transform Camera
    {
        set => displayController.Camera = value;
    }

    public OnSelectWeaponListener OnSeleectWeaponListener
    {
        set => onSeleectWeaponListener = value;
    }

}
