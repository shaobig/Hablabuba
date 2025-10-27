using UnityEngine;

public class ContextNormalizedForceVectorRifleForceCalculatorFactory : Factory<Calculator<Vector3>>
{
    private RifleCollisionContext context;
    private float mass;
    
    public ContextNormalizedForceVectorRifleForceCalculatorFactory(RifleCollisionContext context, float mass)
    {
        this.context = context;
        this.mass = mass;
    }

    public Calculator<Vector3> Get()
    {
        return new NormalizedForceVectorRifleForceCalculatorFactory(
            new ForceVectorRifleForceCalculatorFactory(
                new VectorRifleForceCalculatorFactory(context.HitObject.transform.position, context.HitPoint),
                new ExplosionForceCalculatorFactory(mass, context.Damage)))
                .Get();
    }

}
