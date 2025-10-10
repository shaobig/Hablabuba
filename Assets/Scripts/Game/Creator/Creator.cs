using UnityEngine;

public interface Creator<E>
{
    E Create(GameObject prefab, Transform target);
}
