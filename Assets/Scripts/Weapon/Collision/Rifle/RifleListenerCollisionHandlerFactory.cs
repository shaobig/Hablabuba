// public class RifleListenerCollisionHandlerFactory : Factory<CollisionHandler<RifleCollisionContext>>
// {
//     private onSetCameraOnObjectListener onSetCameraOnObjectListener;
//     private OnAmmoCollideListener onAmmoCollideListener;
//     private ContextRifleForceApplierFactory forceApplierFactory;
//     private RifleDamageCalculatorFactory damageCalculatorFactory;

//     public RifleListenerCollisionHandlerFactory(
//         onSetCameraOnObjectListener onSetCameraOnObjectListener,
//         OnAmmoCollideListener onAmmoCollideListener,
//         ContextRifleForceApplierFactory forceApplierFactory,
//         RifleDamageCalculatorFactory damageCalculatorFactory)
//     {
//         this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
//         this.onAmmoCollideListener = onAmmoCollideListener;
//         this.forceApplierFactory = forceApplierFactory;
//         this.damageCalculatorFactory = damageCalculatorFactory;
//     }

//     public CollisionHandler<RifleCollisionContext> Create()
//     {
//         return new RifleCollisionHandler(onSetCameraOnObjectListener, onAmmoCollideListener, forceApplierFactory, damageCalculatorFactory);
//     }

// }
