using UnityEngine;

public class RifleCollisionContextMonoBehaviourForceHandlerFactory<E> : ForceHandlerFactory<RifleCollisionContext, E> where E: MonoBehaviour
{
    public ForceHandler<RifleCollisionContext, E> Create()
    {
        return new MonoBehaviourForceHandlerFactory<RifleCollisionContext, E>(new RifleCollisionContextForceApplierFactory()).Create();
    }
}
