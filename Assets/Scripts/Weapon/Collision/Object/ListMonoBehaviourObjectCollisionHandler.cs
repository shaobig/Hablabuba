using System.Collections.Generic;

public class ListMonoBehaviourObjectCollisionHandler<C, E> : ObjectCollisionHandler<C, List<E>> where C : CollisionContext
{
    private ObjectCollisionHandler<C, E> objectCollisionHandler;

    public ListMonoBehaviourObjectCollisionHandler(ObjectCollisionHandler<C, E> objectCollisionHandler)
    {
        this.objectCollisionHandler = objectCollisionHandler;
    }

    public void HandleCollision(C context, List<E> entityList)
    {
        entityList.ForEach(entity => objectCollisionHandler.HandleCollision(context, entity));
    }

}
