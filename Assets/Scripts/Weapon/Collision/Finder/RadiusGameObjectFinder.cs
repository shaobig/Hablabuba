using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadiusGameObjectFinder : ObjectFinder<ExplosionCollisionContext, GameObject>
{
    public List<GameObject> Find(ExplosionCollisionContext context)
    {
        return Physics.OverlapSphere(context.ExplosionPoint, context.Radius)
            .Select(collider => collider.gameObject)
            .ToList();
    }

}
