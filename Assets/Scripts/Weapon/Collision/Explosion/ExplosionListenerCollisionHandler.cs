using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionListenerCollisionHandler : ListenerCollisionHandler<ExplosionCollisionContext>
{
    public ExplosionListenerCollisionHandler(
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener) : base(onSetCameraOnShotPlayerListener, onAmmoCollideListener)
    {
    }

    public override void HandleCollision(ExplosionCollisionContext collisionContext)
    {
        List<PlayerController> hitPlayerList = Physics.OverlapSphere(collisionContext.ExplosionPoint, collisionContext.Radius)
            .Select(collider => collider.gameObject)
            .Select(gameObject => gameObject.GetComponent<PlayerController>())
            .Where(playerController => playerController != null)
            .ToList();

        if (hitPlayerList.Count > 0)
        {
            hitPlayerList.ForEach(player => player.OnDamagePlayer(new RadiusDamageCalculator(collisionContext.ExplosionPoint, player.transform.position, collisionContext.Damage, collisionContext.Radius).CalculateDamage()));
            hitPlayerList.Select(player => player.GetComponent<Rigidbody>())
                .ToList()
                .ForEach(rigidbody => new CollisionContextExplosionForceApplierFactory(collisionContext, rigidbody.mass).Get().ApplyForce(rigidbody));
            OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(hitPlayerList);
        }
        else
        {
            OnAmmoCollideListener.OnAmmoCollide();
        }
    }
    
}
