using System.Collections.Generic;

public class RifleListenerCollisionHandler : ListenerCollisionHandler<RifleCollisionContext>
{
    private const string PLAYER_TAG = "Player";

    private DamageCalculator damageCalculator;

    public RifleListenerCollisionHandler(
        DamageCalculator damageCalculator,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener) : base(onSetCameraOnShotPlayerListener, onAmmoCollideListener)
    {
        this.damageCalculator = damageCalculator;
    }

    public override void HandleCollision(RifleCollisionContext context)
    {
        if (context.HitObject.CompareTag(PLAYER_TAG))
        {
            var player = context.HitObject.GetComponent<PlayerController>();
            player.OnDamagePlayer(damageCalculator.CalculateDamage());
            
            OnSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new List<PlayerController> { player });
        }
        else
        {
            OnAmmoCollideListener.OnAmmoCollide();
        }
    }

}
