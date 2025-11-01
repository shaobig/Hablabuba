public class RifleCollisionHandler : CollisionHandler<RifleCollisionContext>
{
    private const string PLAYER_TAG = "Player";

    private ForceHandler<RifleCollisionContext, PlayerController> forceHandler;
    private DamageHandler<RifleCollisionContext, PlayerController> damageHandler;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public RifleCollisionHandler(
        ForceHandler<RifleCollisionContext, PlayerController> forceHandler,
        DamageHandler<RifleCollisionContext, PlayerController> damageHandler,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.forceHandler = forceHandler;
        this.damageHandler = damageHandler;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public void HandleCollision(RifleCollisionContext context)
    {
        if (context.HitObject.CompareTag(PLAYER_TAG))
        {
            var player = context.HitObject.GetComponent<PlayerController>();

            forceHandler.HandleForce(context, player);
            damageHandler.HandleDamage(context, player);

            onSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new() { player });
        }
        else
        {
            onAmmoCollideListener.OnAmmoCollide();
        }
    }

    // public override void HandleCollision(RifleCollisionContext context)
    // {
    //     if (context.HitObject.CompareTag(PLAYER_TAG))
    //     {
    //         var rigidbody = context.HitObject.GetComponent<Rigidbody>();
    //         forceApplierFactory.Create(context, rigidbody.mass).ApplyForce(rigidbody);

    //         var player = context.HitObject.GetComponent<PlayerController>();
    //         player.OnDamagePlayer(damageCalculatorFactory.Create(context.Damage).CalculateDamage());
    //         OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new List<PlayerController> { player });
    //     }
    //     else
    //     {
    //         OnAmmoCollideListener.OnAmmoCollide();
    //     }
    // }

}
