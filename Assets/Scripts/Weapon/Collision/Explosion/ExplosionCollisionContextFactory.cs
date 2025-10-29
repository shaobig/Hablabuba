using UnityEngine;

public class ExplosionCollisionContextFactory : Factory<ExplosionCollisionContext>
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

    public ExplosionCollisionContext Create() => new ExplosionCollisionContextImpl(explosionPoint, radius, damage);

}
