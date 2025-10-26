using UnityEngine;

public class ExplosionForceCalculator : Calculator
{
    private float mass;
    private float damage;
    private float forceAmplifier;

    public ExplosionForceCalculator(float mass, float damage, float forceAmplifier)
    {
        this.mass = mass;
        this.damage = damage;
        this.forceAmplifier = forceAmplifier;
    }

    public float Calculate()
    {
        return mass * damage * forceAmplifier;
    }
    
}
