using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, Mover,
    OnPlayerMoveListener, OnWeaponChangeAngleListener, OnPlayerFireListener,
    OnInventoryToggleListener, OnWeaponSwitchListener, OnWeaponSelectListener,
    OnAmmoShotListener, OnSetCameraOnShotPlayerListener, OnSetCameraOnShotPlayerCompleteListener, OnPlayerKilledListener, OnBulletCollideListener, OnGameFinishedListener
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
        
        playerGameController.Init(playerList, this, this, this, this, this);
        cameraGameController.Init(playerList, this);
        inputGameController.Init(this, this, this, this, this, this);
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

    public void OnPlayerMove(Vector2 moveInput)
    {
        playerGameController.OnPlayerMove(moveInput);
    }

    public void OnInventoryToggle()
    {
        interfaceGameController.OnInventoryToggle();
    }

    public void OnWeaponSwitch(Vector2 switchInput)
    {
        interfaceGameController.OnWeaponSwitch(switchInput);
        playerGameController.CurrentWeaponIndex = interfaceGameController.CurrentWeaponIndex;
    }

    public void OnWeaponSelect()
    {
        playerGameController.OnWeaponSelect();
        interfaceGameController.OnInventoryToggle();
    }

    public void OnWeaponChangeAngle(float scrollInput)
    {
        playerGameController.OnWeaponChangeAngle(scrollInput);
    }

    public void OnPlayerFire()
    {
        playerGameController.OnPlayerFire();
        interfaceGameController.Deactivate();
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
        playerGameController.OnBulletCollide();
        cameraGameController.OnBulletCollide();
        Move();
    }
    
    public void OnBulletCollide()
    {
        playerGameController.OnBulletCollide();
        cameraGameController.OnBulletCollide();
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
