using UnityEngine;

public class WeaponSlotControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WeaponSlotController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WeaponSlotControllerGameObjectConverter GameObjectConverter;

    public WeaponSlotController Create(GameObject prefab, Transform target)
    {
        return GameObjectConverter.Convert(parentGameObjectFactory.Create(prefab, target));
    }

}
