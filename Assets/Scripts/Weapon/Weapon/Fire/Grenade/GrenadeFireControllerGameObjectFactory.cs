using UnityEngine;

public class GrenadeFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<GrenadeFireController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        return parentGameObjectFactory.Create(prefab, target).GetComponent<GrenadeFireController>();
    }

}
