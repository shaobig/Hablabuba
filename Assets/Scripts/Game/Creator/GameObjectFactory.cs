using UnityEngine;

public interface GameObjectFactory<E>
{
    E Create(GameObject prefab, Transform target);
}
