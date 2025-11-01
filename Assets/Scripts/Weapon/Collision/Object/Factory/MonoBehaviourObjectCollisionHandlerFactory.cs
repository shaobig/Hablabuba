// using System.Collections.Generic;

// public class MonoBehaviourObjectCollisionHandlerFactory<C, E> : ObjectCollisionHandlerFactory<C, E> where C: CollisionContext
// {
//     private ForceHandler<C, List<E>> forceHandler;
//     private DamageHandler<C, List<E>> damageHandler;

//     public MonoBehaviourObjectCollisionHandlerFactory(ForceHandler<C, List<E>> forceHandler, DamageHandler<C, List<E>> damageHandler)
//     {
//         this.forceHandler = forceHandler;
//         this.damageHandler = damageHandler;
//     }

//     public ObjectCollisionHandler<C, E> Create()
//     {
//         return new MonoBehaviourObjectCollisionHandler<C, E>(forceHandler, damageHandler);
//     }

// }
