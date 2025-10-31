using UnityEngine;

public interface ForceHandler<C, E> where C: CollisionContext
{
    void HandleForce(C context, E entity);
}
