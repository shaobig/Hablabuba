using UnityEngine;

public class InitPlayerControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<PlayerController>
{
    [SerializeField]
    private PlayerControllerGameObjectFactory playerControllerGameObjectFactory;
    private Player player;

    public PlayerController Create(GameObject prefab, Transform target)
    {
        var playerController = playerControllerGameObjectFactory.Create(prefab, target);
        playerController.Player = player;

        return playerController;
    }

    public Player Player
    {
        set => player = value;
    }

}
