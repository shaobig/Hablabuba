using UnityEngine;

public class MonoBehaviourForceHandlerFactory<C, E> : ForceHandlerFactory<C, E> where C: CollisionContext where E: MonoBehaviour
{
    private ForceApplierFactory<C> forceApplierFactory;

    public MonoBehaviourForceHandlerFactory(ForceApplierFactory<C> forceApplierFactory)
    {
        this.forceApplierFactory = forceApplierFactory;
    }

    public ForceHandler<C, E> Create()
    {
        return new MonoBehaviourForceHandler<C, E>(new RigidbodyForceHandler<C>(forceApplierFactory), new ComponentGameObjectConverter<Rigidbody>());
    }

}
