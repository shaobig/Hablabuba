using UnityEngine;

public class ExplosionCollisionContextImpl : ExplosionCollisionContext
{
    private Vector3 explosionPoint;
    private int radius;
    private int damage;

    public ExplosionCollisionContextImpl(Vector3 explosionPoint, int radius, int damage)
    {
        this.explosionPoint = explosionPoint;
        this.radius = radius;
        this.damage = damage;
    }

    public Vector3 ExplosionPoint => explosionPoint;

    public int Radius => radius;

    public int Damage => damage;
    
}
