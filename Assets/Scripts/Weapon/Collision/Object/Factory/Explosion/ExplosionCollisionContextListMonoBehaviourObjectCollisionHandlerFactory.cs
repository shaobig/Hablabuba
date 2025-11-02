using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollisionContextListMonoBehaviourObjectCollisionHandlerFactory<E> : ObjectCollisionHandlerFactory<ExplosionCollisionContext, List<E>> where E: MonoBehaviour
{
    public ObjectCollisionHandler<ExplosionCollisionContext, List<E>> Create()
    {
        var forceHandler = new ExplosionCollisionContextMonoBehaviourForceHandlerFactory<E>().Create();
        var damageHandler = new ExplosionCollisionContextMonoBehaviourDamageHandlerFactory<E>().Create();

        var ObjectCollisionHandler = new MonoBehaviourObjectCollisionHandlerFactory<ExplosionCollisionContext, E>(forceHandler, damageHandler).Create();
        
        return new ListMonoBehaviourObjectCollisionHandlerFactory<ExplosionCollisionContext, E>(ObjectCollisionHandler).Create();
    }
    
}
