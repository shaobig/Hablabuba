public class RiffleDamageCalculator : DamageCalculator
{
    public int CalculateDamage(Bullet bullet)
    {
        return bullet.Damage;
    }
}
