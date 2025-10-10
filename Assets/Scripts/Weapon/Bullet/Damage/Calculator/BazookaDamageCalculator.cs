using UnityEngine;

public class BazookaDamageCalculator : DamageCalculator
{
    private Vector3 collisionPoint;
    private Vector3 player;

    public BazookaDamageCalculator(Vector3 collisionPoint, Vector3 player)
    {
        this.collisionPoint = collisionPoint;
        this.player = player;
    }

    public int CalculateDamage(Bullet bullet)
    {
        float distance = Vector3.Distance(collisionPoint, player);
        float damage = bullet.Damage * (1 - (distance / bullet.Radius));
        return Mathf.RoundToInt(damage);
    }

    public Vector3 Player
    {
        get => player;
        set => player = value;
    }

}
