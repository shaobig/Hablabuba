using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameController : MonoBehaviour, IndexSetter,
    OnMoveKeyPressedListener,
    OnWeaponChangeAngleKeyPressedListener, OnAimKeyPressedListener, OnFireKeyPressedListener, OnLongFireKeyPressedListener, OnStopFireKeyPressedListener,
    OnWeaponSelectKeyPressedListener,
    OnNextStepPreparedListener, OnNextStepSwitchedListener, OnPlayerKilledListener
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
        OnSelectWeaponListener onSelectWeaponListener,
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnPlayerKilledListener onPlayerKilledListener,
        OnGameFinishedListener onGameFinishedListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener,
        OnNextStepPreparedListener onAmmoCollideListener)
    {
        this.playerList = playerList;
        this.onPlayerKilledListener = onPlayerKilledListener;
        this.onGameFinishedListener = onGameFinishedListener;

        playerList.ForEach(player => player.Init(onSelectWeaponListener, onWeaponProgressBarChangeValueListener, onAimTakenListener, onFireListener, onAmmoShotListener, onAmmoCollideListener, onSetCameraOnObjectListener));
    }

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        currentPlayer.OnMoveKeyPressed(moveInput);
    }

    public void OnAimKeyPressed()
    {
        currentPlayer.OnAimKeyPressed();
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

    public void OnNextStepPrepared()
    {
        currentPlayer.HideWeapon();

        playerList.Where(player => player.IsDead)
            .ToList()
            .ForEach(player => onPlayerKilledListener.OnPlayerKilled(player));
    }

    public void OnNextStepSwitched()
    {
        currentIndex = (currentIndex + 1) % playerList.Count;
        currentPlayer = playerList[currentIndex];

        currentPlayer.Activate();
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

    public void SetIndex(int index)
    {
        currentPlayer.SetIndex(index);
    }

    public PlayerController CurrentPlayer => currentPlayer;

}
