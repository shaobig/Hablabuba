using UnityEngine;

public class MonoBehaviourForceHandler<C, E> : ForceHandler<C, E> where C: CollisionContext where E : MonoBehaviour
{
    private ForceHandler<C, Rigidbody> forceHandler;
    private GameObjectConverter<Rigidbody> GameObjectConverter;

    public MonoBehaviourForceHandler(ForceHandler<C, Rigidbody> forceHandler, GameObjectConverter<Rigidbody> GameObjectConverter)
    {
        this.forceHandler = forceHandler;
        this.GameObjectConverter = GameObjectConverter;
    }

    public void HandleForce(C context, E entity)
    {
        forceHandler.HandleForce(context, GameObjectConverter.Convert(entity.gameObject));
    }

}
