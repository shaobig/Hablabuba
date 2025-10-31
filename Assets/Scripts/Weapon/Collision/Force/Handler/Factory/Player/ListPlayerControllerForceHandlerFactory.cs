using System.Collections.Generic;

public class ListPlayerControllerForceHandlerFactory<C> : ForceHandlerFactory<C, List<PlayerController>> where C: CollisionContext
{
    private ForceApplierFactory<C> forceApplierFactory;

    public ListPlayerControllerForceHandlerFactory(ForceApplierFactory<C> forceApplierFactory)
    {
        this.forceApplierFactory = forceApplierFactory;
    }

    public ForceHandler<C, List<PlayerController>> Create()
    {
        return new ListMonoBehaviourForceHandlerFactory<C, PlayerController>(forceApplierFactory).Create();
    }

}
