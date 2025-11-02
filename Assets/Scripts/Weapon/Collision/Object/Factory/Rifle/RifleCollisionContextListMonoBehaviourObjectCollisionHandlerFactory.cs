using System.Collections.Generic;
using UnityEngine;

public class RifleCollisionContextListMonoBehaviourObjectCollisionHandlerFactory<E> : ObjectCollisionHandlerFactory<RifleCollisionContext, List<E>> where E: MonoBehaviour
{
    public ObjectCollisionHandler<RifleCollisionContext, List<E>> Create()
    {
        var forceHandler = new RifleCollisionContextMonoBehaviourForceHandlerFactory<E>().Create();
        var damageHandler = new RifleCollisionContextMonoBehaviourDamageHandlerFactory<E>().Create();

        var ObjectCollisionHandler = new MonoBehaviourObjectCollisionHandlerFactory<RifleCollisionContext, E>(forceHandler, damageHandler).Create();
        
        return new ListMonoBehaviourObjectCollisionHandlerFactory<RifleCollisionContext, E>(ObjectCollisionHandler).Create();
    }
}
