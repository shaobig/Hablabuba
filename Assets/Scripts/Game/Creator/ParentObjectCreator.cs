using UnityEngine;

public class ParentObjectCreator : MonoBehaviour, Creator<GameObject>
{
    public GameObject Create(GameObject gameObject, Transform target)
    {
        return Instantiate(gameObject, target);
    }

}
