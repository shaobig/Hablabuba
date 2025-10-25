using UnityEngine;

public class ExplosionCollisionContextFactory : CollisionContextFactory<ExplosionCollisionContext>
{
    private Vector3 explosionPoint;
    private int radius;
    private int damage;

    public ExplosionCollisionContextFactory(Vector3 explosionPoint, int radius, int damage)
    {
        this.explosionPoint = explosionPoint;
        this.radius = radius;
        this.damage = damage;
    }

    public ExplosionCollisionContext CollisionContext => new ExplosionCollisionContextImpl(explosionPoint, radius, damage);

}
