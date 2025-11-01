// using System.Collections.Generic;

// public class MonoBehaviourCollisionHandler<C, E> : CollisionHandler<C> where C: CollisionContext
// {
//     private ObjectFinder<C, E> objectFinder;
//     private ObjectCollisionHandler<C, List<E>> objectCollisionHandler;
//     private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
//     private OnAmmoCollideListener onAmmoCollideListener;

//     public MonoBehaviourCollisionHandler(
//         ObjectFinder<C, E> objectFinder,
//         ObjectCollisionHandler<C, List<E>> objectCollisionHandler,
//         OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
//         OnAmmoCollideListener onAmmoCollideListener)
//     {
//         this.objectFinder = objectFinder;
//         this.objectCollisionHandler = objectCollisionHandler;
//         this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
//         this.onAmmoCollideListener = onAmmoCollideListener;
//     }

//     public void HandleCollision(C context)
//     {
//         List<E> entityList = objectFinder.Find(context);
        
//         if (entityList.Count > 0)
//         {
//             objectCollisionHandler.HandleCollision(context, entityList);
//             onSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(entityList);
//         }
//         else
//         {
//             onAmmoCollideListener.OnAmmoCollide();
//         }
//     }
    
// }
