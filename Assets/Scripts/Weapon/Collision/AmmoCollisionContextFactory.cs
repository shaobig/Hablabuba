using UnityEngine;

public class AmmoCollisionContextFactory<C> : CollisionContextFactory<C> where C: CollisionContext
{
    public C CollisionContext => throw new System.NotImplementedException();
}
