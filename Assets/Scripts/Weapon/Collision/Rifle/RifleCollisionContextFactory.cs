using UnityEngine;

public class RifleCollisionContextFactory : Factory<RifleCollisionContext>
{
    private Collision collision;
    private int damage;

    public RifleCollisionContextFactory(Collision collision, int damage)
    {
        this.collision = collision;
        this.damage = damage;
    }

    public RifleCollisionContext Get() => new RifleCollisionContextImpl(collision.gameObject, collision.GetContact(0).point, damage);

}
