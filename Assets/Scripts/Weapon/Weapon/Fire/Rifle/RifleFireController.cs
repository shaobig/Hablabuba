using UnityEngine;

public class RifleFireController : MonoBehaviour, FireController,
    OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private FireControllerEmitter ammoFireController;
    [SerializeField]
    private FireControllerAmmoLoader fireControllerAmmoLoader;
    [SerializeField]
    private int velocity = 50;
    private CollisionHandler<RifleCollisionContext> collisionHandler;
    private AmmoPrefab ammoPrefab;
    private OnFireListener onFireListener;

    public void Init(
        CollisionHandler<RifleCollisionContext> collisionHandler,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener)
    {
        this.collisionHandler = collisionHandler;
        this.onFireListener = onFireListener;

        ammoPrefab = fireControllerAmmoLoader.LoadAmmo();

        ammoFireController.Init(fireControllerAmmoLoader.LoadAmmo(), onAmmoShotListener, this);
        ammoFireController.Velocity = velocity;
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.FIRE.Equals(fireAction))
        {
            ammoFireController.Emit();
            onFireListener.OnFire(WeaponType.RIFLE);
        }
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new RifleCollisionContextFactory(collision, ammoPrefab).Create());
    }

}
