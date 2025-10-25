using UnityEngine;

public abstract class ListenerCollisionHandler<C> : CollisionHandler<C> where C: CollisionContext
{
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public ListenerCollisionHandler(
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public abstract void HandleCollision(C context);

    public OnSetCameraOnShotPlayerListener OnSetCameraOnShotPlayerListener => onSetCameraOnShotPlayerListener;
    public OnAmmoCollideListener OnAmmoCollideListener => onAmmoCollideListener;

}
