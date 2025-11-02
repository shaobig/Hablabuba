using UnityEngine;

public class ExplosionCollisionContextMonoBehaviourDamageHandlerFactory<E> : DamageHandlerFactory<ExplosionCollisionContext, E> where E: MonoBehaviour
{
    public DamageHandler<ExplosionCollisionContext, E> Create()
    {
        return new ExplosionCollisionContextMonoBehaviourDamageHandler<E>(new ComponentGameObjectConverter<Collider>(), new ComponentGameObjectConverter<DamageTaker>(), new ExplosionCollisionContextRadiusDamageCalculatorFactory());
    }
}
