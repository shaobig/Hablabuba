using UnityEngine;

public class PlayerControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<PlayerController>
{
    [SerializeField]
    private SceneGameObjectFactory sceneGameObjectFactory;
    [SerializeField]
    private PlayerControllerGameObjectConverter GameObjectConverter;

    public PlayerController Create(GameObject gameObject, Transform target)
    {
        return GameObjectConverter.Convert(sceneGameObjectFactory.Create(gameObject, target));
    }

}
