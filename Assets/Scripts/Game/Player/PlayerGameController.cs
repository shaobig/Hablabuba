using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameController : MonoBehaviour, Mover,
    OnPlayerMoveListener, OnPlayerFireListener, OnWeaponChangeAngleListener,
    OnWeaponSelectListener,
    OnBulletCollideListener, OnPlayerKilledListener
{
    private const int GAME_OVER_PLAYER_COUNT = 1;

    [SerializeField]
    private PlayerControllerRemover playerControllerRemover;
    private List<PlayerController> playerList;
    private PlayerController currentPlayer;
    private OnPlayerKilledListener onPlayerKilledListener;
    private OnGameFinishedListener onGameFinishedListener;
    private int currentIndex = -1;

    public void Init(List<PlayerController> playerList,
        OnPlayerKilledListener onPlayerKilledListener,
        OnGameFinishedListener onGameFinishedListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnBulletCollideListener onBulletCollideListener)
    {
        this.playerList = playerList;
        this.onPlayerKilledListener = onPlayerKilledListener;
        this.onGameFinishedListener = onGameFinishedListener;
        
        playerList.ForEach(player => player.Init(onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener));
    }

    void OnDestroy()
    {
        playerControllerRemover.Remove(currentPlayer);
    }

    public void Move()
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

    public void OnPlayerMove(Vector2 moveInput)
    {
        currentPlayer.OnPlayerMove(moveInput);
    }

    public void OnWeaponSelect()
    {
        currentPlayer.OnWeaponSelect();
    }

    public void OnWeaponChangeAngle(float scrollInput)
    {
        currentPlayer.OnWeaponChangeAngle(scrollInput);
    }

    public void OnPlayerFire()
    {
        currentPlayer.Fire();
    }

    public PlayerController CurrentPlayer => currentPlayer;

    public int CurrentWeaponIndex
    {
        set => currentPlayer.CurrentWeaponIndex = value;
    }

}
