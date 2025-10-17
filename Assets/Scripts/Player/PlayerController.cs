using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Activator, Deactivator, DisplayRefresher,
    WeaponHolder, WeaponHider,
    OnPlayerMoveListener, OnWeaponChangeAngleListener, OnPlayerFireListener, OnPlayerStopFireListener,
    OnWeaponSelectListener,
    OnBulletCollideOnPlayerListener
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

    public void Init(
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        displayController.Init(player, bodyController.Renderer.material.color);
        displayController.Paint();

        movementController.Init(GetComponent<Rigidbody>());
        movementController.Deactivate();

        inventoryController.Init();

        healthController.Init(player.Health);

        weaponController.Init(onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
    }

    public void OnBulletCollideOnPlayer(HitBullet bullet)
    {
        healthController.OnBulletCollideOnPlayer(bullet);
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

    public void OnWeaponChangeAngle(float scrollInput)
    {
        weaponController.OnWeaponChangeAngle(scrollInput);
    }

    public void OnPlayerFire()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Fire(FireAction.START);
        }
    }

    public void OnPlayerStopFire()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.Fire(FireAction.RELEASE);
        
            movementController.Deactivate();
            weaponController.Deactivate();
        }
    }

    public void HideWeapon()
    {
        weaponController.HideWeapon();
    }

    public void RefreshDisplay()
    {
        displayController.RefreshDisplay();
    }

    public void OnPlayerMove(Vector2 moveInput)
    {
        movementController.OnPlayerMove(moveInput);

        if (Vector2.zero.Equals(moveInput))
        {
            displayController.EnableText();
        }
        else
        {
            displayController.DisableText();
        }
    }

    public void OnWeaponSelect()
    {
        if (weaponController.IsWeaponHeld)
        {
            weaponController.HideWeapon();
        }
        
        weaponController.WeaponItem = inventoryController.SelectWeapon();
        weaponController.HoldWeapon();
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

}
