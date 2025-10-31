using System.Collections.Generic;

public interface ObjectCollisionHandler<C, E> where C: CollisionContext
{
    void HandleCollision(C context, List<E> gameObjectList);
}
