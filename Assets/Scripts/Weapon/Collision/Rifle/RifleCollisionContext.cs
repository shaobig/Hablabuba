using UnityEngine;

public interface RifleCollisionContext : CollisionContext
{
    GameObject HitObject { get; }
}
