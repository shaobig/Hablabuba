using UnityEngine;

public class ExplosionForceApplierFactory : Factory<ForceApplier>
{
    private const float VERTICAL_AMPLIFIER = 1.5f;

    private Vector3 explosionPoint;
    private Factory<Calculator<float>> forceCalculatorFactory;
    private float radius;

    public ExplosionForceApplierFactory(Vector3 explosionPoint, Factory<Calculator<float>> forceCalculatorFactory, float radius)
    {
        this.explosionPoint = explosionPoint;
        this.forceCalculatorFactory = forceCalculatorFactory;
        this.radius = radius;
    }

    public ForceApplier Create()
    {
        return new ExplosionForceApplier(explosionPoint, forceCalculatorFactory.Create(), radius, VERTICAL_AMPLIFIER);
    }

}
