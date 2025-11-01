public interface ObjectCollisionHandlerFactory<C, E> where C: CollisionContext
{
    ObjectCollisionHandler<C, E> Create();
}
