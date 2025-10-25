public class RifleDamageCalculator : DamageCalculator
{
    private int damage;

    public RifleDamageCalculator(int damage)
    {
        this.damage = damage;
    }

    public int CalculateDamage()
    {
        return damage;
    }
    
}
