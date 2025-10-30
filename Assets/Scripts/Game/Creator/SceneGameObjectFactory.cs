using UnityEngine;

public class SceneGameObjectFactory : MonoBehaviour, GameObjectFactory<GameObject>
{
    public GameObject Create(GameObject gameObject, Transform target)
    {
        return Instantiate(gameObject, target.position, target.rotation);
    }

}
