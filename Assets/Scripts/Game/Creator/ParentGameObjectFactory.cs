using UnityEngine;

public class ParentGameObjectFactory : MonoBehaviour, GameObjectFactory<GameObject>
{
    public GameObject Create(GameObject gameObject, Transform target)
    {
        return Instantiate(gameObject, target);
    }

}
