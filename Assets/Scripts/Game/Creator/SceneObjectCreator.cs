using UnityEngine;

public class SceneObjectCreator : MonoBehaviour, Creator<GameObject>
{
    public GameObject Create(GameObject gameObject, Transform target)
    {
        return Instantiate(gameObject, target.position, target.rotation);
    }

}
