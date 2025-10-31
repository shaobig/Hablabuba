public interface CollisionHandlerFactory<C> where C: CollisionContext
{
    CollisionHandler<C> Create();
}
