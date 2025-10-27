using System;
using UnityEngine;

public class ExplosionForceApplier : ForceApplier
{
    private Calculator<float> forceCalculator;
    private Vector3 explosionPosition;
    private float radius;
    private float verticalAmplifier;

    public ExplosionForceApplier(Vector3 explosionPosition, Calculator<float> forceCalculator, float radius, float verticalAmplifier)
    {
        this.forceCalculator = forceCalculator;
        this.explosionPosition = explosionPosition;
        this.radius = radius;
        this.verticalAmplifier = verticalAmplifier;
    }

    public void ApplyForce(Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(forceCalculator.Calculate(), explosionPosition, radius, verticalAmplifier, ForceMode.Impulse);
    }

}
