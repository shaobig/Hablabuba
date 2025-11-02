using System.Collections.Generic;

public class MonoBehaviourCollisionHandlerFactory<C, E> : CollisionHandlerFactory<C> where C: CollisionContext
{
    private ObjectFinder<C, E> objectFinder;
    private ObjectCollisionHandler<C, List<E>> objectCollisionHandler;
    private OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public MonoBehaviourCollisionHandlerFactory(
        ObjectFinder<C, E> objectFinder,
        ObjectCollisionHandler<C, List<E>> objectCollisionHandler,
        OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.objectFinder = objectFinder;
        this.objectCollisionHandler = objectCollisionHandler;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public CollisionHandler<C> Create()
    {
        return new MonoBehaviourCollisionHandler<C, E>(objectFinder, objectCollisionHandler, onSetCameraOnObjectListener, onAmmoCollideListener);
    }
}
