using UnityEngine;

public class InitPlayerControllerCreator : MonoBehaviour, Creator<PlayerController>
{
    [SerializeField]
    private PlayerControllerCreator playerControllerCreator;
    private Player player;
    private WindowController windowController;

    public PlayerController Create(GameObject gameObject, Transform target)
    {
        var playerController = playerControllerCreator.Create(gameObject, target);
        playerController.Init(player, windowController);

        return playerController;
    }

    public Player Player
    {
        get => player;
        set => player = value;
    }

    public WindowController WindowController
    {
        get => windowController;
        set => windowController = value;
    }

}
