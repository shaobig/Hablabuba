
// using System.Collections.Generic;

// public class ExplosionContextCollisionHandlerFactory : CollisionHandlerFactory<ExplosionCollisionContext>
// {
//     private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
//     private OnAmmoCollideListener onAmmoCollideListener;

//     public ExplosionContextCollisionHandlerFactory(OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener, OnAmmoCollideListener onAmmoCollideListener)
//     {
//         this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
//         this.onAmmoCollideListener = onAmmoCollideListener;
//     }

//     public CollisionHandler<ExplosionCollisionContext> Create()
//     {
//         return new MonoBehaviourCollisionHandler<ExplosionCollisionContext, PlayerController>(
//             new ExplosionCollisionContextListMonoBehaviourObjectFinderFactory<PlayerController>().Create(),
//             new MonoBehaviourObjectCollisionHandlerFactory<ExplosionCollisionContext, List<PlayerController>(new ExplosionListPlayerControllerForceHandlerFactory().Create(), new ExplosionCollisionContextColliderDamageHandlerFactory<>().Create()).Create(), onSetCameraOnShotPlayerListener, onAmmoCollideListener);
//     }
    
// }
