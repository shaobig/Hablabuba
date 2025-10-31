using System.Collections.Generic;

public class PlayerControllerObjectCollisionHandler : ObjectCollisionHandler<ExplosionCollisionContext, PlayerController>
{
    private ForceHandler<ExplosionCollisionContext, List<PlayerController>> forceHandler;
    private DamageHandler<ExplosionCollisionContext, List<PlayerController>> damageHandler;

    public PlayerControllerObjectCollisionHandler(ForceHandler<ExplosionCollisionContext, List<PlayerController>> forceHandler, DamageHandler<ExplosionCollisionContext, List<PlayerController>> damageHandler)
    {
        this.forceHandler = forceHandler;
        this.damageHandler = damageHandler;
    }
    
    public void HandleCollision(ExplosionCollisionContext context, List<PlayerController> playerList)
    {
        forceHandler.HandleForce(context, playerList);
        damageHandler.HandleDamage(context, playerList);
    }
    
}
