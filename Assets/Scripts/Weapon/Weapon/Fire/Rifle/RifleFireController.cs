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
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onFireListener = onFireListener;

        ammoPrefab = fireControllerAmmoLoader.LoadAmmo();
        collisionHandler = new RifleListenerCollisionHandler(onSetCameraOnShotPlayerListener, onAmmoCollideListener, new RifleDamageCalculator(ammoPrefab.Ammo.Damage));

        ammoFireController.Init(ammoPrefab, onAmmoShotListener, this);
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
        collisionHandler.HandleCollision(new RifleCollisionContextFactory(collision, ammoPrefab).Get());
    }

}
