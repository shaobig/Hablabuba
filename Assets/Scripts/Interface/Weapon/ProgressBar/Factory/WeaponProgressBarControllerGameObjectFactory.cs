using UnityEngine;

public class WeaponProgressBarControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WeaponProgressBarController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WeaponProgressBarControllerGameObjectConverter gameObjectConverter;

    public WeaponProgressBarController Create(GameObject prefab, Transform canvas)
    {
        return gameObjectConverter.Convert(parentGameObjectFactory.Create(prefab, canvas));
    }

}
