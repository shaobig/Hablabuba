using UnityEngine;

public class RifleCollisionContextFactory : Factory<RifleCollisionContext>
{
    private Collision collision;
    private AmmoPrefab ammoPrefab;

    public RifleCollisionContextFactory(Collision collision, AmmoPrefab ammoPrefab)
    {
        this.collision = collision;
        this.ammoPrefab = ammoPrefab;
    }

    public RifleCollisionContext Create() => new RifleCollisionContextImpl(collision.gameObject, collision.GetContact(0).point, ammoPrefab.Ammo.Damage);

}
