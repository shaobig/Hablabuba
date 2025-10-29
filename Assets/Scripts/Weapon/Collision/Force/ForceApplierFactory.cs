public interface ForceApplierFactory<C> where C: CollisionContext
{
    ForceApplier Create(C context, float mass);
}
