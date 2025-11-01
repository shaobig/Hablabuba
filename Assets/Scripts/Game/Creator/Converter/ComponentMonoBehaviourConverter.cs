using UnityEngine;

public class ComponentGameObjectConverter<E> : GameObjectConverter<E>
{
    public E Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<E>();
    }
}
