public interface ForceHandlerFactory<C, E> where C: CollisionContext
{
    ForceHandler<C, E> Create();
}
