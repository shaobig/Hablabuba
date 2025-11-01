using UnityEngine;

public class ExplosionCollisionContextListMonoBehaviourObjectFinderFactory<E> : ObjectFinderFactory<ExplosionCollisionContext, E> where E: MonoBehaviour
{
    public ObjectFinder<ExplosionCollisionContext, E> Create()
    {
        return new ListMonoBehaviourObjectFinder<ExplosionCollisionContext, E>(new RadiusGameObjectFinder(), new ComponentGameObjectConverter<E>());
    }
}
