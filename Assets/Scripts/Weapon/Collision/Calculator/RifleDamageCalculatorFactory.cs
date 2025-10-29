public class RifleDamageCalculatorFactory : DamageCalculatorFactory
{
    public DamageCalculator Create(int damage)
    {
        return new RifleDamageCalculator(damage);
    }

}
