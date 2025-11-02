using UnityEngine;

public class RifleCollisionContextMonoBehaviourDamageHandlerFactory<E> : DamageHandlerFactory<RifleCollisionContext, E> where E: MonoBehaviour
{
    public DamageHandler<RifleCollisionContext, E> Create()
    {
        return new RifleCollisionContextMonoBehaviourDamageHandler<E>(new ComponentGameObjectConverter<DamageTaker>());
    }
}
