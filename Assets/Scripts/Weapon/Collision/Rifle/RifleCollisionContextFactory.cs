using UnityEngine;

public class RifleCollisionContextFactory : CollisionContextFactory<RifleCollisionContext>
{
    private Collision collision;
    private int damage;

    public RifleCollisionContextFactory(Collision collision, int damage)
    {
        this.collision = collision;
        this.damage = damage;
    }

    public RifleCollisionContext CollisionContext => new RifleCollisionContextImpl(collision.gameObject, damage);

}
