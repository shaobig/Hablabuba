using UnityEngine;

public class RigidbodyForceHandler<C> : ForceHandler<C, Rigidbody> where C: CollisionContext
{
    private ForceApplierFactory<C> forceApplierFactory;

    public RigidbodyForceHandler(ForceApplierFactory<C> forceApplierFactory)
    {
        this.forceApplierFactory = forceApplierFactory;
    }

    public void HandleForce(C context, Rigidbody rigidbody)
    {
        forceApplierFactory.Create(context, rigidbody.mass).ApplyForce(rigidbody);
    }

}
