using UnityEngine;

public class WeaponProgressBarControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WeaponProgressBarController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WeaponProgressBarControllerGameObjectConverter monoBehaviourCreator;

    public WeaponProgressBarController Create(GameObject prefab, Transform canvas)
    {
        return monoBehaviourCreator.Convert(parentGameObjectFactory.Create(prefab, canvas));
    }

}
