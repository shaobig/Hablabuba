using UnityEngine;

public class GameObjectRemover : MonoBehaviour, Remover<GameObject>
{

    public void Remove(GameObject gameObject)
    {
        Destroy(gameObject);
    }

}
