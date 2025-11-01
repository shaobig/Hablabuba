
using UnityEngine;

public class AmmoControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AmmoController>
{
    [SerializeField]
    private SceneGameObjectFactory sceneGameObjectFactory;
    [SerializeField]
    private AmmoControllerGameObjectConverter GameObjectConverter;

    public AmmoController Create(GameObject prefab, Transform target)
    {
        return GameObjectConverter.Convert(sceneGameObjectFactory.Create(prefab, target));
    }

}
