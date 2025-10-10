public class DamageHandlerFactory
{   
    public DamageHandler GetDamageHandler(BulletType type)
    {
        if (BulletType.BAZOOKA.Equals(type))
        {
            return new BazookaDamageHandler();
        }
        else
        {
            return new RiffleDamageHandler();
        }
    }

}
