using UnityEngine;

public class WeaponSlotControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WeaponSlotController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WeaponSlotControllerGameObjectConverter gameObjectConverter;

    public WeaponSlotController Create(GameObject prefab, Transform target)
    {
        return gameObjectConverter.Convert(parentGameObjectFactory.Create(prefab, target));
    }

}
