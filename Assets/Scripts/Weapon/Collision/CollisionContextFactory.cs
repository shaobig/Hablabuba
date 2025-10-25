public interface CollisionContextFactory<C> where C: CollisionContext
{
    C CollisionContext { get; }
}
