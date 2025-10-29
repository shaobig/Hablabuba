using UnityEngine;

public class RadiusDamageCalculator : DamageCalculator
{
    private Vector3 point;
    private Vector3 target;
    private int damage;
    private int radius;

    public RadiusDamageCalculator(Vector3 point, Vector3 target, int damage, int radius)
    {
        this.point = point;
        this.target = target;
        this.damage = damage;
        this.radius = radius;
    }

    public int CalculateDamage()
    {
        float distance = Vector3.Distance(point, target);
        float fixedDamage = damage * (1 - (distance / radius));
        return Mathf.RoundToInt(fixedDamage);
    }
    
}
