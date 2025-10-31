using System.Collections.Generic;

public class ExplosionListPlayerControllerForceHandlerFactory : ForceHandlerFactory<ExplosionCollisionContext, List<PlayerController>>
{
    public ForceHandler<ExplosionCollisionContext, List<PlayerController>> Create()
    {
        return new ListPlayerControllerForceHandlerFactory<ExplosionCollisionContext>(new ContextExplosionForceApplierFactory()).Create();
    }

}
