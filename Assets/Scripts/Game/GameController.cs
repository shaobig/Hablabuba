using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour,
    OnAmmoShotListener, OnSetCameraOnShotPlayerListener, OnSetCameraOnShotPlayerCompleteListener, OnPlayerKilledListener, OnBulletCollideListener, OnGameFinishedListener
{
    private const float GAME_OVER_TIMESCALE = 0;

    [SerializeField]
    private RespawnGameController respawnGameController;
    [SerializeField]
    private PlayerGameController playerGameController;
    [SerializeField]
    private CameraGameController cameraGameController;
    [SerializeField]
    private float timeScale = 1;
    private List<PlayerController> playerList;

    void Awake()
    {
        playerList = respawnGameController.Respawn();
        playerGameController.Init(playerList, this, this, this, this, this);
        cameraGameController.Init(playerList, this);
    }

    void Start()
    {
        playerGameController.GoToNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
    }

    void Update()
    {
        Time.timeScale = timeScale;
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

        playerGameController.GoToNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
    }

    public void OnPlayerKilled(PlayerController player)
    {
        playerGameController.OnPlayerKilled(player);
    }

    public void OnBulletCollide()
    {
        playerGameController.OnBulletCollide();
        cameraGameController.OnBulletCollide();

        playerGameController.GoToNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
    }

    public void OnGameFinished()
    {
        Debug.Log("Game over");
        Time.timeScale = GAME_OVER_TIMESCALE;

        enabled = false;
    }

}
