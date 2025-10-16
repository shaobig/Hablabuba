using UnityEngine;

public class InitPlayerControllerCreator : MonoBehaviour, Creator<PlayerController>
{
    [SerializeField]
    private PlayerControllerCreator playerControllerCreator;
    private Player player;

    public PlayerController Create(GameObject prefab, Transform target)
    {
        var playerController = playerControllerCreator.Create(prefab, target);
        playerController.Player = player;

        return playerController;
    }

    public Player Player
    {
        set => player = value;
    }

}
