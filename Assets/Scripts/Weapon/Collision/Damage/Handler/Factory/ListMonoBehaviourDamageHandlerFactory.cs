// using System.Collections.Generic;
// using UnityEngine;

// public class ListMonoBehaviourDamageHandlerFactory<C, E> : DamageHandlerFactory<C, List<E>> where C: CollisionContext where E: MonoBehaviour
// {
//     private DamageHandler<C, Collider> damageHandler;

//     public ListMonoBehaviourDamageHandlerFactory(DamageHandler<C, Collider> damageHandler)
//     {
//         this.damageHandler = damageHandler;
//     }

//     public DamageHandler<C, List<E>> Create()
//     {
//         return new ListMonoBehaviourDamageHandler<C, E>(new MonoBehaviourDamageHandler<C, E>(damageHandler, new ComponentGameObjectConverter<Collider>()));
//     }

// }
