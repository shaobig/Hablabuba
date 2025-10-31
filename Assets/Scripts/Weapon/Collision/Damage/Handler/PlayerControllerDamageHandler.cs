using UnityEngine;

public class PlayerControllerDamageHandler : DamageHandler<ExplosionCollisionContext, PlayerController>
{
    private RadiusDamageCalculatorFactory damageCalculatorFactory;

    public PlayerControllerDamageHandler(RadiusDamageCalculatorFactory damageCalculatorFactory)
    {
        this.damageCalculatorFactory = damageCalculatorFactory;
    }

    public void HandleDamage(ExplosionCollisionContext context, PlayerController player)
    {
        Collider collider = player.GetComponent<Collider>();
        DamageCalculator damageCalculator = damageCalculatorFactory.Create(context, collider.ClosestPoint(context.ExplosionPoint));
        player.OnDamagePlayer(damageCalculator.CalculateDamage());
    }

}
