using System.Collections.Generic;

public class ExplosionCollisionHandler : CollisionHandler<ExplosionCollisionContext>
{
    private ObjectFinder<ExplosionCollisionContext, PlayerController> objectFinder;
    private ObjectCollisionHandler<ExplosionCollisionContext, PlayerController> objectCollisionHandler;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public ExplosionCollisionHandler(
        ObjectFinder<ExplosionCollisionContext, PlayerController> objectFinder,
        ObjectCollisionHandler<ExplosionCollisionContext, PlayerController> objectCollisionHandler,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.objectFinder = objectFinder;
        this.objectCollisionHandler = objectCollisionHandler;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public void HandleCollision(ExplosionCollisionContext context)
    {
        List<PlayerController> hitPlayerList = objectFinder.Find(context);
        
        if (hitPlayerList.Count > 0)
        {
            objectCollisionHandler.HandleCollision(context, hitPlayerList);
            onSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(hitPlayerList);
        }
        else
        {
            onAmmoCollideListener.OnAmmoCollide();
        }
    }
    
}
