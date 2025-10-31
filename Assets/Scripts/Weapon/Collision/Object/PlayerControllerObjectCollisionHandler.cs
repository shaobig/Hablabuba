using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControllerObjectCollisionHandler : ObjectCollisionHandler<ExplosionCollisionContext, PlayerController>
{
    private ForceApplierFactory<ExplosionCollisionContext> forceApplierFactory;
    private DamageHandler<ExplosionCollisionContext, List<PlayerController>> damageHandler;

    public PlayerControllerObjectCollisionHandler(ForceApplierFactory<ExplosionCollisionContext> forceApplierFactory, DamageHandler<ExplosionCollisionContext, List<PlayerController>> damageHandler)
    {
        this.forceApplierFactory = forceApplierFactory;
        this.damageHandler = damageHandler;
    }
    
    public void HandleCollision(ExplosionCollisionContext context, List<PlayerController> playerList)
    {
        playerList.Select(player => player.GetComponent<Rigidbody>())
            .ToList()
            .ForEach(rigidbody => forceApplierFactory.Create(context, rigidbody.mass).ApplyForce(rigidbody));
        damageHandler.HandleDamage(context, playerList);
    }
    
}
