public interface DamageHandler<C, E> where C: CollisionContext
{
    void HandleDamage(C context, E entity);
}
