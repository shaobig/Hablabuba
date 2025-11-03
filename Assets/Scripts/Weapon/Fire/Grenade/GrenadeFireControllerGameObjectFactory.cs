using UnityEngine;

public class GrenadeShooterGameObjectFactory : MonoBehaviour, GameObjectFactory<GrenadeShootController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;

    public GrenadeShootController Create(GameObject prefab, Transform target)
    {
        return parentGameObjectFactory.Create(prefab, target).GetComponent<GrenadeShootController>();
    }

}
