using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionListenerCollisionHandler : ListenerCollisionHandler<ExplosionCollisionContext>
{
    private ForceApplierFactory<ExplosionCollisionContext> forceApplierFactory;
    private RadiusDamageCalculatorFactory damageCalculatorFactory;

    public ExplosionListenerCollisionHandler(
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener,
        ForceApplierFactory<ExplosionCollisionContext> forceApplierFactory,
        RadiusDamageCalculatorFactory damageCalculatorFactory) : base(onSetCameraOnShotPlayerListener, onAmmoCollideListener)
    {
        this.forceApplierFactory = forceApplierFactory;
        this.damageCalculatorFactory = damageCalculatorFactory;
    }

    public override void HandleCollision(ExplosionCollisionContext context)
    {
        List<PlayerController> hitPlayerList = Physics.OverlapSphere(context.ExplosionPoint, context.Radius)
            .Select(collider => collider.gameObject)
            .Select(gameObject => gameObject.GetComponent<PlayerController>())
            .Where(playerController => playerController != null)
            .ToList();

        if (hitPlayerList.Count > 0)
        {
            hitPlayerList
                .ForEach(player =>
                {
                    DamageCalculator damageCalculator = damageCalculatorFactory.Create(context, player.GetComponent<BoxCollider>().ClosestPoint(context.ExplosionPoint));
                    player.OnDamagePlayer(damageCalculator.CalculateDamage());
                });
            hitPlayerList.Select(player => player.GetComponent<Rigidbody>())
                .ToList()
                .ForEach(rigidbody => forceApplierFactory.Create(context, rigidbody.mass).ApplyForce(rigidbody));
            OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(hitPlayerList);
        }
        else
        {
            OnAmmoCollideListener.OnAmmoCollide();
        }
    }
    
}
