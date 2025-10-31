public class CollisionHandlerRifleDamageCalculatorFactory : RifleDamageCalculatorFactory
{
    public DamageCalculator Create(int damage)
    {
        return new CollisionHandlerRifleDamageCalculator(damage);
    }

}
