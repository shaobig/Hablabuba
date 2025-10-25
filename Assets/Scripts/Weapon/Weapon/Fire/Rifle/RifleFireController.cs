using UnityEngine;

public class RifleFireController : MonoBehaviour, FireController,
    OnAmmoCollideWithTerrainListener
{
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private AmmoPrefab ammoPrefab;
    [SerializeField]
    private int velocity = 50;
    private CollisionHandler<RifleCollisionContext> collisionHandler;
    private WeaponItem weaponItem;
    private OnFireListener onFireListener;

    public void Init(
        WeaponItem weaponItem,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.weaponItem = weaponItem;
        this.onFireListener = onFireListener;

        collisionHandler = new RifleListenerCollisionHandler(new RifleDamageCalculator(ammoPrefab.Ammo.Damage), onSetCameraOnShotPlayerListener, onAmmoCollideListener);

        ammoEmitter.Init(emitPoint, ammoPrefab, onAmmoShotListener, this);
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.FIRE.Equals(fireAction))
        {
            ammoEmitter.Velocity = velocity;
            ammoEmitter.Emit();
            
            onFireListener.OnFire(weaponItem.Weapon.Type);
        }
    }

    public void OnAmmoCollideWithTerrain(Collision collision)
    {
        collisionHandler.HandleCollision(new RifleCollisionContextImpl(collision.gameObject, ammoPrefab.Ammo.Damage));
    }

}
