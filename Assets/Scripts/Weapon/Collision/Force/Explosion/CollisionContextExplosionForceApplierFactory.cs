using UnityEngine;

public class CollisionContextExplosionForceApplierFactory : Factory<ForceApplier>
{
    private ExplosionCollisionContext collisionContext;
    private float mass;

    public CollisionContextExplosionForceApplierFactory(ExplosionCollisionContext collisionContext, float mass)
    {
        this.collisionContext = collisionContext;
        this.mass = mass;
    }

    public ForceApplier Get()
    {
        return new ExplosionForceApplierFactory(collisionContext.ExplosionPoint, new ExplosionForceCalculatorFactory(mass, collisionContext.Damage), collisionContext.Radius).Get();
    }

}
