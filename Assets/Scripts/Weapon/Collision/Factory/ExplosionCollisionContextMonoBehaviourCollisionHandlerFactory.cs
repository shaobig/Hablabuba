using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory<E> : CollisionHandlerFactory<ExplosionCollisionContext> where E: MonoBehaviour
{
    private OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory(OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener, OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public CollisionHandler<ExplosionCollisionContext> Create()
    {
        return new MonoBehaviourCollisionHandlerFactory<ExplosionCollisionContext, E>(new ExplosionCollisionContextMonoBehaviourObjectFinderFactory<E>().Create(), new ExplosionCollisionContextListMonoBehaviourObjectCollisionHandlerFactory<E>().Create(), onSetCameraOnObjectListener, onAmmoCollideListener).Create();
    }

}
