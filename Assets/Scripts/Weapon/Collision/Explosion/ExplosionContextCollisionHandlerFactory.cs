
// using System.Collections.Generic;

// public class ExplosionContextCollisionHandlerFactory : CollisionHandlerFactory<ExplosionCollisionContext>
// {
//     private onSetCameraOnObjectListener onSetCameraOnObjectListener;
//     private OnAmmoCollideListener onAmmoCollideListener;

//     public ExplosionContextCollisionHandlerFactory(onSetCameraOnObjectListener onSetCameraOnObjectListener, OnAmmoCollideListener onAmmoCollideListener)
//     {
//         this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
//         this.onAmmoCollideListener = onAmmoCollideListener;
//     }

//     public CollisionHandler<ExplosionCollisionContext> Create()
//     {
//         return new MonoBehaviourCollisionHandler<ExplosionCollisionContext, PlayerController>(
//             new ExplosionCollisionContextListMonoBehaviourObjectFinderFactory<PlayerController>().Create(),
//             new MonoBehaviourObjectCollisionHandlerFactory<ExplosionCollisionContext, List<PlayerController>(new ExplosionListPlayerControllerForceHandlerFactory().Create(), new ExplosionCollisionContextColliderDamageHandlerFactory<>().Create()).Create(), onSetCameraOnObjectListener, onAmmoCollideListener);
//     }
    
// }
