using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameController : MonoBehaviour, Mover,
    OnMoveKeyPressedListener, OnWeaponChangeAngleKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener,
    OnWeaponSelectKeyPressedListener,
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

    public void Init(
        List<PlayerController> playerList,
        OnSelectWeaponListener onSeleectWeaponListener,
        OnFireListener onFireListener,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnPlayerKilledListener onPlayerKilledListener,
        OnGameFinishedListener onGameFinishedListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnBulletCollideListener onBulletCollideListener)
    {
        this.playerList = playerList;
        this.onPlayerKilledListener = onPlayerKilledListener;
        this.onGameFinishedListener = onGameFinishedListener;
        
        playerList.ForEach(player => player.Init(onSeleectWeaponListener, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener));
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

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        currentPlayer.OnMoveKeyPressed(moveInput);
    }

    public void OnWeaponSelectKeyPressed()
    {
        currentPlayer.OnWeaponSelectKeyPressed();
    }

    public void OnWeaponChangeAngleKeyPressed(float scrollInput)
    {
        currentPlayer.OnWeaponChangeAngleKeyPressed(scrollInput);
    }

    public void OnFireKeyPressed()
    {
        currentPlayer.OnFireKeyPressed();
    }

    public void OnLongFireKeyPressed()
    {
        currentPlayer.OnLongFireKeyPressed();
    }

    public void OnStopFireKeyPressed()
    {
        currentPlayer.OnStopFireKeyPressed();
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

    public PlayerController CurrentPlayer => currentPlayer;

    public int CurrentWeaponIndex
    {
        set => currentPlayer.CurrentWeaponIndex = value;
    }

}
