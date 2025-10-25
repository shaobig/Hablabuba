public interface CollisionHandler<C> where C : CollisionContext
{
    void HandleCollision(C context);
}
