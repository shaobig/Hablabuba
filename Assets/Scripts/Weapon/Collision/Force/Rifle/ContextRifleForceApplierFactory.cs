public class ContextRifleForceApplierFactory : Factory<ForceApplier>
{
    private RifleCollisionContext context;
    private float mass;

    public ContextRifleForceApplierFactory(RifleCollisionContext context, float mass)
    {
        this.context = context;
        this.mass = mass;
    }

    public ForceApplier Get()
    {
        return new RifleForceApplierFactory(new ContextNormalizedForceVectorRifleForceCalculatorFactory(context, mass)).Get();
    }

}
