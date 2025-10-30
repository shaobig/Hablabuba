using UnityEngine;

public class PlayerControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<PlayerController>
{
    [SerializeField]
    private SceneGameObjectFactory sceneGameObjectFactory;
    [SerializeField]
    private PlayerControllerGameObjectConverter gameObjectConverter;

    public PlayerController Create(GameObject gameObject, Transform target)
    {
        return gameObjectConverter.Convert(sceneGameObjectFactory.Create(gameObject, target));
    }

}
