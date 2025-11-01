public interface DamageHandlerFactory<C, E> where C: CollisionContext
{
    DamageHandler<C, E> Create();
}
