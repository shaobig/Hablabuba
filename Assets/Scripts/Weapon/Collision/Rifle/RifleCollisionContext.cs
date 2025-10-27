using UnityEngine;

public interface RifleCollisionContext : CollisionContext
{
    GameObject HitObject { get; }
    Vector3 HitPoint { get; }
}
