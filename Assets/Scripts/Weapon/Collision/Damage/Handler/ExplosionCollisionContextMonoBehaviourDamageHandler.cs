using UnityEngine;

public class ExplosionCollisionContextMonoBehaviourDamageHandler<E> : DamageHandler<ExplosionCollisionContext, E> where E: MonoBehaviour
{
    private GameObjectConverter<Collider> colliderGameObjectConverter;
    private GameObjectConverter<DamageTaker> damageTakerGameObjectConverter;
    private RadiusDamageCalculatorFactory radiusDamageCalculatorFactory;

    public ExplosionCollisionContextMonoBehaviourDamageHandler(GameObjectConverter<Collider> colliderGameObjectConverter, GameObjectConverter<DamageTaker> damageTakerGameObjectConverter, RadiusDamageCalculatorFactory radiusDamageCalculatorFactory)
    {
        this.colliderGameObjectConverter = colliderGameObjectConverter;
        this.damageTakerGameObjectConverter = damageTakerGameObjectConverter;
        this.radiusDamageCalculatorFactory = radiusDamageCalculatorFactory;
    }

    public void HandleDamage(ExplosionCollisionContext context, E entity)
    {
        Collider collider = colliderGameObjectConverter.Convert(entity.gameObject);
        int damage = radiusDamageCalculatorFactory.Create(context, collider.ClosestPoint(context.ExplosionPoint)).CalculateDamage();

        damageTakerGameObjectConverter.Convert(entity.gameObject).TakeDamage(damage);
    }
    
}
