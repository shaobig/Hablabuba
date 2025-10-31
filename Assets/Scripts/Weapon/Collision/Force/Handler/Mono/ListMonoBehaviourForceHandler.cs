using System.Collections.Generic;
using UnityEngine;

public class ListMonoBehaviourForceHandler<C, E> : ForceHandler<C, List<E>> where C: CollisionContext where E: MonoBehaviour
{
    private ForceHandler<C, E> forceHandler;

    public ListMonoBehaviourForceHandler(ForceHandler<C, E> forceHandler)
    {
        this.forceHandler = forceHandler;
    }

    public void HandleForce(C context, List<E> entityList)
    {
        entityList.ForEach(entity => forceHandler.HandleForce(context, entity));
    }

}
