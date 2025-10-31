using UnityEngine;

public class RifleFireController : MonoBehaviour, FireController,
    OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private LoaderAmmoEmitter loaderAmmoEmitter;
    [SerializeField]
    private int velocity = 25;
    private CollisionHandler<RifleCollisionContext> collisionHandler;
    private OnFireListener onFireListener;

    public void Init(
        CollisionHandler<RifleCollisionContext> collisionHandler,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener)
    {
        this.collisionHandler = collisionHandler;
        this.onFireListener = onFireListener;

        loaderAmmoEmitter.Init(onAmmoShotListener, this);
        loaderAmmoEmitter.Velocity = velocity;
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.FIRE.Equals(fireAction))
        {
            loaderAmmoEmitter.Emit();
            onFireListener.OnFire(WeaponType.RIFLE);
        }
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new RifleCollisionContextFactory(collision, loaderAmmoEmitter.AmmoPrefab).Create());
    }

}
