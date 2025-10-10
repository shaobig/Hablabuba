using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, ListenerSubscriber, ListenerUnsubscriber,
    OnAmmoShotListener, OnBulletCollideListener, OnSetCameraOnShotPlayerListener, OnSetCameraOnShotPlayerCompleteListener, OnGameFinishedListener
{
    private const float TIMESCALE_FINISH_GAME = 0;

    [SerializeField]
    private PlayerGameController playerGameController;
    [SerializeField]
    private CameraGameController cameraGameController;
    [SerializeField]
    private float timeScale = 1;

    void Awake()
    {
        cameraGameController.Init(this);
        SubscribeListener();
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

    void OnDestroy()
    {
        UnsubscribeListener();
    }

    public void SubscribeListener()
    {
        playerGameController.OnAmmoShotListener = this;
        playerGameController.OnBulletCollideListener = this;
        playerGameController.OnSetOnShotPlayerCameraListener = this;
        playerGameController.OnGameFinishedListener = this;
    }

    public void UnsubscribeListener()
    {
        playerGameController.OnAmmoShotListener = null;
        playerGameController.OnBulletCollideListener = null;
        playerGameController.OnSetOnShotPlayerCameraListener = null;
        playerGameController.OnGameFinishedListener = null;
    }

    public void OnAmmoShot(Transform ammo)
    {
        cameraGameController.OnAmmoShot(ammo);
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        cameraGameController.OnSetCameraOnShotPlayer(playerList);
    }

    public void OnBulletCollide()
    {
        playerGameController.OnBulletCollide();
        cameraGameController.OnBulletCollide();

        playerGameController.GoToNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
    }

    public void OnSetCameraOnShotPlayerComplete()
    {
        playerGameController.OnBulletCollide();
        cameraGameController.OnBulletCollide();

        playerGameController.GoToNextStep();
        cameraGameController.Follow(playerGameController.CurrentPlayer.transform);
    }

    public void OnGameFinished()
    {
        Debug.Log("Game over");
        Time.timeScale = TIMESCALE_FINISH_GAME;
    }

}
