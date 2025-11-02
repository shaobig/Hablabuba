using System.Collections.Generic;
using UnityEngine;

public class RifleCollisionContextMonoBehaviourCollisionHandlerFactory<E> : CollisionHandlerFactory<RifleCollisionContext> where E: MonoBehaviour
{
    private string tag;
    private OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public RifleCollisionContextMonoBehaviourCollisionHandlerFactory(
        string tag,
        OnSetCameraOnObjectListener<List<E>> onSetCameraOnObjectListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.tag = tag;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public CollisionHandler<RifleCollisionContext> Create()
    {
        return new MonoBehaviourCollisionHandlerFactory<RifleCollisionContext, E>(new RifleCollisionContextMonoBehaviourObjectFinderFactory<E>(tag).Create(), new RifleCollisionContextListMonoBehaviourObjectCollisionHandlerFactory<E>().Create(), onSetCameraOnObjectListener, onAmmoCollideListener).Create();
    }
}
