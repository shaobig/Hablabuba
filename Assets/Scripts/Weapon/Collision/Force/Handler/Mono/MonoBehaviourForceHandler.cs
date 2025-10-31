using UnityEngine;

public class MonoBehaviourForceHandler<C, E> : ForceHandler<C, E> where C: CollisionContext where E : MonoBehaviour
{
    private ForceHandler<C, Rigidbody> forceHandler;
    private GameObjectConverter<Rigidbody> gameObjectConverter;

    public MonoBehaviourForceHandler(ForceHandler<C, Rigidbody> forceHandler, GameObjectConverter<Rigidbody> gameObjectConverter)
    {
        this.forceHandler = forceHandler;
        this.gameObjectConverter = gameObjectConverter;
    }

    public void HandleForce(C context, E entity)
    {
        forceHandler.HandleForce(context, gameObjectConverter.Convert(entity.gameObject));
    }

}
