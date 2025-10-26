public class ExplosionForceCalculatorFactory : Factory<Calculator>
{
    private const float FORCE_AMPLIFIER = 0.25f;

    private float mass;
    private float damage;

    public ExplosionForceCalculatorFactory(float mass, float damage)
    {
        this.mass = mass;
        this.damage = damage;
    }

    public Calculator Get()
    {
        return new ExplosionForceCalculator(mass, damage, FORCE_AMPLIFIER);
    }

}
