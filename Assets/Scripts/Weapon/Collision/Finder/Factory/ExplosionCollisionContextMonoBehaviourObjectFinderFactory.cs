using UnityEngine;

public class ExplosionCollisionContextMonoBehaviourObjectFinderFactory<E> : ObjectFinderFactory<ExplosionCollisionContext, E> where E: MonoBehaviour
{
    public ObjectFinder<ExplosionCollisionContext, E> Create()
    {
        return new MonoBehaviourObjectFinder<ExplosionCollisionContext, E>(new RadiusGameObjectFinder(), new ComponentGameObjectConverter<E>());
    }

}
