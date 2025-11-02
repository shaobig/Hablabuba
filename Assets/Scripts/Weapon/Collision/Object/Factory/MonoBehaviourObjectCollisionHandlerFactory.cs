public class MonoBehaviourObjectCollisionHandlerFactory<C, E> : ObjectCollisionHandlerFactory<C, E> where C: CollisionContext
{
    private ForceHandler<C, E> forceHandler;
    private DamageHandler<C, E> damageHandler;

    public MonoBehaviourObjectCollisionHandlerFactory(ForceHandler<C, E> forceHandler, DamageHandler<C, E> damageHandler)
    {
        this.forceHandler = forceHandler;
        this.damageHandler = damageHandler;
    }

    public ObjectCollisionHandler<C, E> Create()
    {
        return new MonoBehaviourObjectCollisionHandler<C, E>(forceHandler, damageHandler);
    }

}
