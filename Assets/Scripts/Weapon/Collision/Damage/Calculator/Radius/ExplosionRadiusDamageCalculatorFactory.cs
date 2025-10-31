using UnityEngine;

public class ExplosionRadiusDamageCalculatorFactory : RadiusDamageCalculatorFactory
{
    public DamageCalculator Create(ExplosionCollisionContext context, Vector3 playerPosition)
    {
        return new RadiusDamageCalculator(context.ExplosionPoint, playerPosition, context.Damage, context.Radius);
    }
}
