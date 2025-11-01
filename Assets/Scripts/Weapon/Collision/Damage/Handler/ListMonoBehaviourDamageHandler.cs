using System.Collections.Generic;

public class ListMonoBehaviourDamageHandler<C, E> : DamageHandler<C, List<E>> where C: CollisionContext
{
    private DamageHandler<C, E> damageHandler;

    public ListMonoBehaviourDamageHandler(DamageHandler<C, E> damageHandler)
    {
        this.damageHandler = damageHandler;
    }

    public void HandleDamage(C context, List<E> entityList)
    {
        entityList.ForEach(entity => damageHandler.HandleDamage(context, entity));
    }

}
