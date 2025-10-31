
public class ExplosionCollisionHandlerFactory : CollisionHandlerFactory<ExplosionCollisionContext>
{
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public ExplosionCollisionHandlerFactory(OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener, OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public CollisionHandler<ExplosionCollisionContext> Create()
    {
        return new ExplosionCollisionHandler(new PlayerControllerRadiusObjectFinderFactory().Create(), new PlayerControllerObjectCollisionHandler(new ContextExplosionForceApplierFactory(), new ListPlayerControllerDamageHandler(new PlayerControllerDamageHandler(new ExplosionRadiusDamageCalculatorFactory()))), onSetCameraOnShotPlayerListener, onAmmoCollideListener);
    }
    
}
