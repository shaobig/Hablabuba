using UnityEngine;

public interface GameObjectConverter<E>
{
    E Convert(GameObject gameObject);
}
