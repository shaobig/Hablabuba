public class MonoBehaviourObjectCollisionHandler<C, E> : ObjectCollisionHandler<C, E> where C: CollisionContext
{
    private ForceHandler<C, E> forceHandler;
    private DamageHandler<C, E> damageHandler;

    public MonoBehaviourObjectCollisionHandler(ForceHandler<C, E> forceHandler, DamageHandler<C, E> damageHandler)
    {
        this.forceHandler = forceHandler;
        this.damageHandler = damageHandler;
    }
    
    public void HandleCollision(C context, E entity)
    {
        forceHandler.HandleForce(context, entity);
        damageHandler.HandleDamage(context, entity);
    }
    
}
