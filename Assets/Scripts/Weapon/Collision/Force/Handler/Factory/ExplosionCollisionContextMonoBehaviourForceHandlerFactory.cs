using UnityEngine;

public class ExplosionCollisionContextMonoBehaviourForceHandlerFactory<E> : ForceHandlerFactory<ExplosionCollisionContext, E> where E: MonoBehaviour
{
    public ForceHandler<ExplosionCollisionContext, E> Create()
    {
        return new MonoBehaviourForceHandlerFactory<ExplosionCollisionContext, E>(new ContextExplosionForceApplierFactory()).Create();
    }

}
