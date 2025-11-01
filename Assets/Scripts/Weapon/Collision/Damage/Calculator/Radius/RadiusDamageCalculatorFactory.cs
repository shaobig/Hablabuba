using UnityEngine;

public interface RadiusDamageCalculatorFactory
{
    DamageCalculator Create(ExplosionCollisionContext context, Vector3 colliderPosition);
}
