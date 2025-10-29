using System.Collections.Generic;
using UnityEngine;

public class RifleListenerCollisionHandler : ListenerCollisionHandler<RifleCollisionContext>
{
    private const string PLAYER_TAG = "Player";

    private ForceApplierFactory<RifleCollisionContext> forceApplierFactory;
    private DamageCalculatorFactory damageCalculatorFactory;

    public RifleListenerCollisionHandler(
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener,
        ForceApplierFactory<RifleCollisionContext> forceApplierFactory,
        DamageCalculatorFactory damageCalculatorFactory) : base(onSetCameraOnShotPlayerListener, onAmmoCollideListener)
    {
        this.forceApplierFactory = forceApplierFactory;
        this.damageCalculatorFactory = damageCalculatorFactory;
    }

    public override void HandleCollision(RifleCollisionContext context)
    {
        if (context.HitObject.CompareTag(PLAYER_TAG))
        {
            var rigidbody = context.HitObject.GetComponent<Rigidbody>();
            forceApplierFactory.Create(context, rigidbody.mass).ApplyForce(rigidbody);
            
            var player = context.HitObject.GetComponent<PlayerController>();
            player.OnDamagePlayer(damageCalculatorFactory.Create(context.Damage).CalculateDamage());
            OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new List<PlayerController> { player });
        }
        else
        {
            OnAmmoCollideListener.OnAmmoCollide();
        }
    }

}
