using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour,
    OnMoveKeyPressedListener,
    OnAimKeyPressedListener, OnAimKeyReleasedListener, OnWeaponChangeAngleKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener,
    OnInventoryOpenKeyPressedListener, OnWeaponSwitchKeyPressedListener, OnWeaponSelectKeyPressedListener,
    OnSelectWeaponListener, OnAimTakenListener, OnFireListener, OnWeaponProgressBarChangeValueListener,
    OnAmmoShotListener, OnSetCameraOnObjectListener<List<PlayerController>>, OnSetCameraOnObjectCompleteListener, OnPlayerKilledListener, OnAmmoCollideListener, OnGameFinishedListener
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
        
        playerGameController.Init(playerList, this, this, this, this, this, this, this, this, this);
        cameraGameController.Init(playerList, this);
        inputGameController.Init(this, this, this, this, this, this, this, this, this, this);
        interfaceGameController.Init();
    }

    void Start()
    {
        SetNextStep();
    }

    void Update()
    {
        Time.timeScale = timeScale;
    }

    public void SetNextStep()
    {
        playerGameController.SetNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
        interfaceGameController.FillWindow(playerGameController.CurrentPlayer.WeaponItemList);
    }

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        playerGameController.OnMoveKeyPressed(moveInput);
    }

    public void OnAimKeyPressed()
    {
        playerGameController.OnAimKeyPressed();
    }

    public void OnAimKeyReleased()
    {
        cameraGameController.OnAimKeyReleased();
    }

    public void OnInventoryOpenKeyPressed()
    {
        interfaceGameController.OnInventoryOpenKeyPressed();
    }

    public void OnWeaponSwitchKeyPressed(Vector2 switchInput)
    {
        interfaceGameController.OnWeaponSwitchKeyPressed(switchInput);
        playerGameController.SetIndex(interfaceGameController.CurrentWeaponIndex);
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

    public void OnAimTaken(Transform aimPoint)
    {
        cameraGameController.OnAimTaken(aimPoint);
    }

    public void OnFire(WeaponType weaponType)
    {
        interfaceGameController.OnFire(weaponType);
        playerGameController.SetIndex(interfaceGameController.ResetIndex());
    }

    public void OnAmmoShot(Transform ammo)
    {
        cameraGameController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnObjectList(List<PlayerController> playerList)
    {
        cameraGameController.OnSetCameraOnObjectList(playerList);
    }

    public void OnSetCameraOnObjectComplete()
    {
        cameraGameController.OnSetCameraOnObjectComplete();
        playerGameController.OnAmmoCollide();
        SetNextStep();
    }
    
    public void OnAmmoCollide()
    {
        playerGameController.OnAmmoCollide();
        cameraGameController.OnAmmoCollide();
        SetNextStep();
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
