using System.Collections.Generic;
using UnityEngine;

public class RifleListenerCollisionHandler : ListenerCollisionHandler<RifleCollisionContext>
{
    private const string PLAYER_TAG = "Player";

    private DamageCalculator damageCalculator;

    public RifleListenerCollisionHandler(
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener,
        DamageCalculator damageCalculator) : base(onSetCameraOnShotPlayerListener, onAmmoCollideListener)
    {
        this.damageCalculator = damageCalculator;
    }

    public override void HandleCollision(RifleCollisionContext context)
    {
        if (context.HitObject.CompareTag(PLAYER_TAG))
        {
            var rigidbody = context.HitObject.GetComponent<Rigidbody>();
            new ContextRifleForceApplierFactory(context, rigidbody.mass).Get().ApplyForce(rigidbody);
            
            var player = context.HitObject.GetComponent<PlayerController>();
            player.OnDamagePlayer(damageCalculator.CalculateDamage());
            OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new List<PlayerController> { player });
        }
        else
        {
            OnAmmoCollideListener.OnAmmoCollide();
        }
    }

}
