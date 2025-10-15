using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameController : MonoBehaviour,
    OnBulletCollideListener, OnPlayerKilledListener
{
    private const int GAME_OVER_PLAYER_COUNT = 1;

    private const KeyCode OPEN_INVENTORY_KEY = KeyCode.I;
    private const KeyCode SELECT_WEAPON_KEY = KeyCode.Space;
    private const KeyCode FIRE_WEAPON_KEY = KeyCode.Mouse0;

    [SerializeField]
    private PlayerControllerRemover playerControllerRemover;
    private List<PlayerController> playerList;
    private PlayerController currentPlayer;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnPlayerKilledListener onPlayerKilledListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnGameFinishedListener onGameFinishedListener;
    private int currentIndex = -1;

    public void Init(List<PlayerController> playerList,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnBulletCollideListener onBulletCollideListener,
        OnPlayerKilledListener onPlayerKilledListener,
        OnGameFinishedListener onGameFinishedListener)
    {
        this.playerList = playerList;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onPlayerKilledListener = onPlayerKilledListener;
        this.onGameFinishedListener = onGameFinishedListener;

        playerList.ForEach(player =>
        {
            player.OnAmmoShotListener = onAmmoShotListener;
            player.OnSetOnShotPlayerCameraListener = onSetCameraOnShotPlayerListener;
            player.OnBulletCollideListener = onBulletCollideListener;
            player.OnPlayerKilledListener = onPlayerKilledListener;
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(OPEN_INVENTORY_KEY))
        {
            currentPlayer.OpenInventory();
        }
        else if (Input.GetKeyDown(SELECT_WEAPON_KEY))
        {
            currentPlayer.HoldWeapon();
        }
        else if (Input.GetKeyDown(FIRE_WEAPON_KEY))
        {
            currentPlayer.Fire();
        }
    }

    void OnDestroy()
    {
        playerControllerRemover.Remove(currentPlayer);
    }

    public void GoToNextStep()
    {
        currentIndex = (currentIndex + 1) % playerList.Count;
        currentPlayer = playerList[currentIndex];

        currentPlayer.Activate();
    }

    public void OnBulletCollide()
    {
        currentPlayer.HideWeapon();

        playerList.Where(player => player.IsDead)
            .ToList()
            .ForEach(player => onPlayerKilledListener.OnPlayerKilled(player));
    }

    public void OnPlayerKilled(PlayerController player)
    {
        int killedIndex = playerList.IndexOf(player);
        playerList.RemoveAt(killedIndex);

        playerControllerRemover.Remove(player);
        
        if (playerList.Count <= GAME_OVER_PLAYER_COUNT)
        {
            onGameFinishedListener.OnGameFinished();
        }

        if (currentIndex > killedIndex)
        {
            currentIndex--;
        }
        currentIndex = (currentIndex + playerList.Count) % playerList.Count;
    }

    public PlayerController CurrentPlayer
    {
        get => currentPlayer;
    }

    public OnAmmoShotListener OnAmmoShotListener
    {
        get => onAmmoShotListener;
        set => onAmmoShotListener = value;
    }

    public OnSetCameraOnShotPlayerListener OnSetOnShotPlayerCameraListener
    {
        get => onSetCameraOnShotPlayerListener;
        set => onSetCameraOnShotPlayerListener = value;
    }

    public OnPlayerKilledListener OnPlayerKilledListener
    {
        get => onPlayerKilledListener;
        set => onPlayerKilledListener = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        get => onBulletCollideListener;
        set => onBulletCollideListener = value;
    }

}
