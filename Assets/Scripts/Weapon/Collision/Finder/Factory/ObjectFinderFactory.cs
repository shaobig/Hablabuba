public interface ObjectFinderFactory<C, E> where C: CollisionContext
{
    ObjectFinder<C, E> Create();
}
