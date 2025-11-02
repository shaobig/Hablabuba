using System.Collections.Generic;

public class ListMonoBehaviourObjectCollisionHandlerFactory<C, E> : ObjectCollisionHandlerFactory<C, List<E>> where C : CollisionContext
{
    private ObjectCollisionHandler<C, E> objectCollisionHandler;

    public ListMonoBehaviourObjectCollisionHandlerFactory(ObjectCollisionHandler<C, E> objectCollisionHandler)
    {
        this.objectCollisionHandler = objectCollisionHandler;
    }

    public ObjectCollisionHandler<C, List<E>> Create()
    {
        return new ListMonoBehaviourObjectCollisionHandler<C, E>(objectCollisionHandler);
    }
    
}
