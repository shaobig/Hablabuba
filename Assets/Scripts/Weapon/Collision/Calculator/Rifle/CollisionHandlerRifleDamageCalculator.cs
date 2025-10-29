public class CollisionHandlerRifleDamageCalculator : DamageCalculator
{
    private int damage;

    public CollisionHandlerRifleDamageCalculator(int damage)
    {
        this.damage = damage;
    }

    public int CalculateDamage()
    {
        return damage;
    }
    
}
