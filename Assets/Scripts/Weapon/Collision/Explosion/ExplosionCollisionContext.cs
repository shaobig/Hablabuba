using UnityEngine;

public interface ExplosionCollisionContext : CollisionContext
{
    Vector3 ExplosionPoint { get; }
    int Radius { get; }
}
