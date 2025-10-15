using UnityEngine;

public class PlayerController : MonoBehaviour, Activator, Deactivator, DisplayRefresher,
    WeaponHolder, WeaponHider, FireController, InventoryOpener,
    OnBulletCollideOnPlayerListener, OnBulletCollideListener
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
    private OnPlayerKilledListener onPlayerKilledListener;

    public void Init(Player player, WindowController windowController)
    {
        this.player = player;

        InitDisplayController(player);
        InitMovementController();
        InitInventoryController(windowController);
        InitHealthController(player.Health);
        InitWeaponController();
    }

    void InitDisplayController(Player player)
    {
        displayController.Init(player, bodyController.Renderer.material.color);
        displayController.Paint();
    }

    void InitMovementController()
    {
        var playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true;

        movementController.Init(playerRigidbody);
        movementController.Deactivate();
    }

    void InitInventoryController(WindowController windowController)
    {
        inventoryController.Init(windowController);
    }

    void InitHealthController(int health)
    {
        healthController.Init(health);
    }

    void InitWeaponController()
    {
        weaponController.Init();
    }

    void FixedUpdate()
    {
        if (movementController.IsMoving)
        {
            displayController.DisableText();
        }
        else
        {
            displayController.EnableText();
        }
    }

    public void OnBulletCollideOnPlayer(HitBullet bullet)
    {
        healthController.OnBulletCollideOnPlayer(bullet);
        displayController.SetHealthText(healthController.Health);
    }

    public void OnBulletCollide()
    {
        if (healthController.IsDead)
        {
            onPlayerKilledListener.OnPlayerKilled(this);
        }
    }

    public void Activate()
    {
        enabled = true;

        movementController.Activate();
        weaponController.Activate();
        inventoryController.Activate();
    }

    public void Deactivate()
    {
        enabled = false;
        movementController.Deactivate();
    }

    public void OpenInventory()
    {
        if (inventoryController.IsOpened)
        {
            inventoryController.CloseInventory();
            movementController.Activate();
        }
        else
        {
            inventoryController.OpenInventory();
            movementController.Deactivate();
        }
    }

    public void HoldWeapon()
    {
        if (inventoryController.IsOpened)
        {
            if (weaponController.IsWeaponHeld)
            {
                weaponController.HideWeapon();
            }

            inventoryController.CloseInventory();
            movementController.Activate();

            weaponController.Weapon = inventoryController.SelectWeapon();
            weaponController.HoldWeapon();
        }
    }

    public void Fire()
    {
        if (weaponController.IsWeaponHeld)
        {
            movementController.Deactivate();

            weaponController.Fire();
            weaponController.Deactivate();

            inventoryController.Deactivate();
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

    public Player Player
    {
        get => player;
        set => player = value;
    }

    public OnPlayerKilledListener OnPlayerKilledListener
    {
        set => onPlayerKilledListener = value;
    }

    public Transform Camera
    {
        set => displayController.Camera = value;
    }

    public OnAmmoShotListener OnAmmoShotListener
    {
        set => weaponController.OnAmmoShotListener = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        set => weaponController.OnBulletCollideListener = value;
    }

    public OnSetCameraOnShotPlayerListener OnSetOnShotPlayerCameraListener
    {
        set => weaponController.OnSetOnShotPlayerCameraListener = value;
    }

    public bool IsDead => healthController.IsDead;

}
