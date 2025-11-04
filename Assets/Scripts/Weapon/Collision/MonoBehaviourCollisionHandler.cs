using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourCollisionHandler<C, E> : CollisionHandler<C> where C: CollisionContext
{
    private ObjectFinder<C, E> objectFinder;
    private ObjectCollisionHandler<C, List<E>> objectCollisionHandler;
    private OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener;
    private OnNextStepPreparedListener onAmmoCollideListener;

    public MonoBehaviourCollisionHandler(
        ObjectFinder<C, E> objectFinder,
        ObjectCollisionHandler<C, List<E>> objectCollisionHandler,
        OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener,
        OnNextStepPreparedListener onAmmoCollideListener)
    {
        this.objectFinder = objectFinder;
        this.objectCollisionHandler = objectCollisionHandler;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public void HandleCollision(C context)
    {
        List<E> entityList = objectFinder.Find(context);

        if (entityList.Count > 0)
        {
            objectCollisionHandler.HandleCollision(context, entityList);
            onSetCameraOnObjectListener.OnSetCameraOnObjectList(entityList);
        }
        else
        {
            onAmmoCollideListener.OnNextStepPrepared();
        }
    }
    
}
