
using UnityEngine;

public class AmmoControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AmmoController>
{
    [SerializeField]
    private SceneGameObjectFactory sceneGameObjectFactory;
    [SerializeField]
    private AmmoControllerGameObjectConverter gameObjectConverter;

    public AmmoController Create(GameObject prefab, Transform target)
    {
        return gameObjectConverter.Convert(sceneGameObjectFactory.Create(prefab, target));
    }

}
