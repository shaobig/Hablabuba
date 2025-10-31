using System.Collections.Generic;
using UnityEngine;

public class ListMonoBehaviourForceHandlerFactory<C, E> : ForceHandlerFactory<C, List<E>> where C: CollisionContext where E: MonoBehaviour
{
    private ForceApplierFactory<C> forceApplierFactory;

    public ListMonoBehaviourForceHandlerFactory(ForceApplierFactory<C> forceApplierFactory)
    {
        this.forceApplierFactory = forceApplierFactory;
    }

    public ForceHandler<C, List<E>> Create()
    {
        return new ListMonoBehaviourForceHandler<C, E>(new MonoBehaviourForceHandler<C, E>(new RigidbodyForceHandler<C>(forceApplierFactory), new ComponentGameObjectConverter<Rigidbody>()));
    }

}
