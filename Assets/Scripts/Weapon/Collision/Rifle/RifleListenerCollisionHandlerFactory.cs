// public class RifleListenerCollisionHandlerFactory : Factory<CollisionHandler<RifleCollisionContext>>
// {
//     private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
//     private OnAmmoCollideListener onAmmoCollideListener;
//     private ContextRifleForceApplierFactory forceApplierFactory;
//     private RifleDamageCalculatorFactory damageCalculatorFactory;

//     public RifleListenerCollisionHandlerFactory(
//         OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
//         OnAmmoCollideListener onAmmoCollideListener,
//         ContextRifleForceApplierFactory forceApplierFactory,
//         RifleDamageCalculatorFactory damageCalculatorFactory)
//     {
//         this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
//         this.onAmmoCollideListener = onAmmoCollideListener;
//         this.forceApplierFactory = forceApplierFactory;
//         this.damageCalculatorFactory = damageCalculatorFactory;
//     }

//     public CollisionHandler<RifleCollisionContext> Create()
//     {
//         return new RifleCollisionHandler(onSetCameraOnShotPlayerListener, onAmmoCollideListener, forceApplierFactory, damageCalculatorFactory);
//     }

// }
