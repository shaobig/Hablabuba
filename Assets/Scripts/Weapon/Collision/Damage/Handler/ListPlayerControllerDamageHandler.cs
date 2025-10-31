using System.Collections.Generic;

public class ListPlayerControllerDamageHandler : DamageHandler<ExplosionCollisionContext, List<PlayerController>>
{
    private DamageHandler<ExplosionCollisionContext, PlayerController> damageHandler;

    public ListPlayerControllerDamageHandler(DamageHandler<ExplosionCollisionContext, PlayerController> damageHandler)
    {
        this.damageHandler = damageHandler;
    }

    public void HandleDamage(ExplosionCollisionContext context, List<PlayerController> playerList)
    {
        playerList.ForEach(player => damageHandler.HandleDamage(context, player));
    }

}
