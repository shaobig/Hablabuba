using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListMonoBehaviourObjectFinder<C, E> : ObjectFinder<C, E> where C: CollisionContext where E: MonoBehaviour
{
    private ObjectFinder<C, GameObject> objectFinder;
    private GameObjectConverter<E> gameObjectConverter;

    public ListMonoBehaviourObjectFinder(ObjectFinder<C, GameObject> objectFinder, GameObjectConverter<E> gameObjectConverter)
    {
        this.objectFinder = objectFinder;
        this.gameObjectConverter = gameObjectConverter;
    }

    public List<E> Find(C context)
    {
        return objectFinder.Find(context)
            .Select(gameObject => gameObjectConverter.Convert(gameObject))
            .Where(entity => entity != null)
            .ToList();
    }
    
}
