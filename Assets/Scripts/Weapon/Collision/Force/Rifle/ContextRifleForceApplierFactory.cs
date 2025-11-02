public class RifleCollisionContextForceApplierFactory : ForceApplierFactory<RifleCollisionContext>
{ 
    public ForceApplier Create(RifleCollisionContext context, float mass)
    {
        return new RifleForceApplierFactory(new ContextNormalizedForceVectorRifleForceCalculatorFactory(context, mass)).Create();
    }
}
