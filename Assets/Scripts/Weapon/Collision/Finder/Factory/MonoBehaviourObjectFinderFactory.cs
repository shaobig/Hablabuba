using UnityEngine;

public class MonoBehaviourObjectFinderFactory<C, E> : ObjectFinderFactory<C, E> where C: CollisionContext where E: MonoBehaviour
{
    private ObjectFinder<C, GameObject> objectFinder;

    public MonoBehaviourObjectFinderFactory(ObjectFinder<C, GameObject> objectFinder)
    {
        this.objectFinder = objectFinder;
    } 

    public ObjectFinder<C, E> Create()
    {
        return new MonoBehaviourObjectFinder<C, E>(objectFinder, new ComponentGameObjectConverter<E>());
    }

}
