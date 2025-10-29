public class ContextExplosionForceApplierFactory : ForceApplierFactory<ExplosionCollisionContext>
{
    public ForceApplier Create(ExplosionCollisionContext context, float mass)
    {
        return new ExplosionForceApplierFactory(context.ExplosionPoint, new ExplosionForceCalculatorFactory(mass, context.Damage), context.Radius).Create();
    }

}
