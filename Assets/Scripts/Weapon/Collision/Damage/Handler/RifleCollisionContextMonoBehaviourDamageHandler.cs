using UnityEngine;

public class RifleCollisionContextMonoBehaviourDamageHandler<E> : DamageHandler<RifleCollisionContext, E> where E: MonoBehaviour
{
    private GameObjectConverter<DamageTaker> damageTakeGameObjectConverter;

    public RifleCollisionContextMonoBehaviourDamageHandler(GameObjectConverter<DamageTaker> damageTakeGameObjectConverter)
    {
        this.damageTakeGameObjectConverter = damageTakeGameObjectConverter;
    }

    public void HandleDamage(RifleCollisionContext context, E entity)
    {
        damageTakeGameObjectConverter.Convert(entity.gameObject).TakeDamage(context.Damage);
    }

}
