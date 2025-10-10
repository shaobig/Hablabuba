using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour, ListenerSubscriber, ListenerUnsubscriber, OnBulletCollideListener, OnPlayerKilledListener
{
    private const KeyCode OPEN_INVENTORY_KEY = KeyCode.I;
    private const KeyCode SELECT_WEAPON_KEY = KeyCode.Space;
    private const KeyCode FIRE_WEAPON_KEY = KeyCode.Mouse0;

    private const int GAME_OVER_PLAYER_COUNT = 1;

    [SerializeField]
    private DatabasePlayerRespawner playerRespawner;
    [SerializeField]
    private PlayerCameraController playerCameraController;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    private List<PlayerController> playerList;
    private PlayerController currentPlayer;
    private OnGameFinishedListener onGameFinishedListener;
    private int currentIndex = -1;

    void Awake()
    {
        playerList = playerRespawner.Respawn();
    }

    void Start()
    {
        SubscribeListener();
    }

    void OnDestroy()
    {
        UnsubscribeListener();
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
            currentPlayer.Emit();
        }
    }

    void FixedUpdate()
    {
        UpdateDisplay();
    }

    public void SubscribeListener()
    {
        playerList.ForEach(player =>
        {
            player.OnBulletCollideListener = this;
            player.OnPlayerKilledListener = this;
        });
    }

    public void UnsubscribeListener()
    {
        playerList.ForEach(player =>
        {
            player.OnBulletCollideListener = null;
            player.OnPlayerKilledListener = null;
        });
    }

    public void GoToNextStep()
    {
        currentIndex = (currentIndex + 1) % playerList.Count;
        currentPlayer = playerList[currentIndex];

        currentPlayer.Activate();

        SetPlayerCameraTarget();
    }

    void SetPlayerCameraTarget()
    {
        playerCameraController.Target = currentPlayer.transform;
    }

    public void OnBulletCollide()
    {
        currentPlayer.HideWeapon();
        GoToNextStep();
    }

    public void OnPlayerKilled(PlayerController player)
    {
        int killedIndex = playerList.IndexOf(player);
        playerList.RemoveAt(killedIndex);

        gameObjectRemover.Remove(player.gameObject);

        if (playerList.Count == GAME_OVER_PLAYER_COUNT)
        {
            onGameFinishedListener.OnGameFinished();
        }
        if (currentIndex > killedIndex)
        {
            currentIndex--;
        }
        currentIndex = (currentIndex + playerList.Count) % playerList.Count;
    }

    void UpdateDisplay()
    {
        playerList.ForEach(player =>
        {
            player.CurrentPlayer = currentPlayer;

            player.TurnDisplay();
            player.MakeDisplaySize();
        });
    }

    public OnGameFinishedListener OnGameFinishedListener
    {
        get => onGameFinishedListener;
        set => onGameFinishedListener = value;
    }

}
