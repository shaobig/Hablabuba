public interface ObjectCollisionHandler<C, E> where C: CollisionContext
{
    void HandleCollision(C context, E entity);
}
