public interface ObjectFinderFactory<C, O> where C: CollisionContext
{
    ObjectFinder<C, O> Create();
}
