using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, Mover,
    OnMoveKeyPressedListener, OnWeaponChangeAngleKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener,
    OnInventoryOpenKeyPressedListener, OnWeaponSwitchKeyPressedListener, OnWeaponSelectKeyPressedListener,
    OnSelectWeaponListener, OnFireListener, OnWeaponProgressBarChangeValueListener,
    OnAmmoShotListener, OnSetCameraOnShotPlayerListener, OnSetCameraOnShotPlayerCompleteListener, OnPlayerKilledListener, OnAmmoCollideListener, OnGameFinishedListener
{
    [SerializeField]
    private RespawnGameController respawnGameController;
    [SerializeField]
    private PlayerGameController playerGameController;
    [SerializeField]
    private CameraGameController cameraGameController;
    [SerializeField]
    private InputGameController inputGameController;
    [SerializeField]
    private InterfaceGameController interfaceGameController;
    [SerializeField]
    private float timeScale = 1;

    void Awake()
    {
        var playerList = respawnGameController.Respawn();
        
        playerGameController.Init(playerList, this, this, this, this, this, this, this, this);
        cameraGameController.Init(playerList, this);
        inputGameController.Init(this, this, this, this, this, this, this, this);
        interfaceGameController.Init();
    }

    void Start()
    {
        Move();
    }

    void Update()
    {
        Time.timeScale = timeScale;
    }

    public void Move()
    {
        playerGameController.Move();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
        interfaceGameController.FillWindow(playerGameController.CurrentPlayer.WeaponItemList);
    }

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        playerGameController.OnMoveKeyPressed(moveInput);
    }

    public void OnInventoryOpenKeyPressed()
    {
        interfaceGameController.OnInventoryOpenKeyPressed();
    }

    public void OnWeaponSwitchKeyPressed(Vector2 switchInput)
    {
        interfaceGameController.OnWeaponSwitchKeyPressed(switchInput);
        playerGameController.CurrentWeaponIndex = interfaceGameController.CurrentWeaponIndex;
    }

    public void OnWeaponSelectKeyPressed()
    {
        playerGameController.OnWeaponSelectKeyPressed();
        interfaceGameController.OnInventoryOpenKeyPressed();
    }
    public void OnSelectWeapon(WeaponType weaponType)
    {
        interfaceGameController.OnSelectWeapon(weaponType);
    }

    public void OnWeaponChangeAngleKeyPressed(float scrollInput)
    {
        playerGameController.OnWeaponChangeAngleKeyPressed(scrollInput);
    }

    public void OnWeaponProgressBarChangeValue(float value)
    {
        interfaceGameController.OnWeaponProgressBarChangeValue(value);
    }

    public void OnFireKeyPressed()
    {
        playerGameController.OnFireKeyPressed();
    }

    public void OnLongFireKeyPressed()
    {
        playerGameController.OnLongFireKeyPressed();
    }

    public void OnStopFireKeyPressed()
    {
        playerGameController.OnStopFireKeyPressed();
    }

    public void OnFire(WeaponType weaponType)
    {
        interfaceGameController.OnFire(weaponType);
    }

    public void OnAmmoShot(Transform ammo)
    {
        cameraGameController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        cameraGameController.OnSetCameraOnShotPlayer(playerList);
    }

    public void OnSetCameraOnShotPlayerComplete()
    {
        cameraGameController.OnSetCameraOnShotPlayerComplete();
        playerGameController.OnAmmoCollide();
        Move();
    }
    
    public void OnAmmoCollide()
    {
        playerGameController.OnAmmoCollide();
        cameraGameController.OnAmmoCollide();
        Move();
    }

    public void OnPlayerKilled(PlayerController player)
    {
        playerGameController.OnPlayerKilled(player);
    }

    public void OnGameFinished()
    {
        Debug.Log("Game over");
        enabled = false;
    }

}
