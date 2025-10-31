using UnityEngine;

public class GrenadeFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener, OnGrenadeDestroyListener
{
    [SerializeField]
    private GrenadeThrower grenadeThrower;
    [SerializeField]
    private GrenadeRigidbodyRotator grenadeRigidbodyRotator;
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private float force = 10f;
    [SerializeField]
    private int radius = 30;
    [SerializeField]
    private int damage = 60;
    private CollisionHandler<ExplosionCollisionContext> collisionHandler;
    private new Rigidbody rigidbody;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private bool isGrenadeFlying;

    public void Init(
        CollisionHandler<ExplosionCollisionContext> collisionHandler,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener
        )
    {
        this.collisionHandler = collisionHandler;
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;

        rigidbody = GetComponent<Rigidbody>();

        weaponTimer.Init(this, this);
        grenadeThrower.Init(rigidbody, this);
    }

    void FixedUpdate()
    {
        if (isGrenadeFlying)
        {
            transform.rotation = grenadeRigidbodyRotator.Rotate(rigidbody);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrenadeFlying = false;
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.LONG_FIRE.Equals(fireAction))
        {
            weaponTimer.Activate();
        }
        if (FireAction.STOP.Equals(fireAction))
        {
            weaponTimer.Deactivate();
            onFireListener.OnFire(WeaponType.GRENADE);
        }
    }

    public void OnTimerCount(float elapsedTime)
    {
        onWeaponProgressBarChangeValueListener.OnWeaponProgressBarChangeValue(1 - (elapsedTime / weaponTimer.MaxTime));
    }

    public void OnTimerFinish(float elapsedTime)
    {
        grenadeThrower.Force = (1 - (elapsedTime / weaponTimer.MaxTime)) * force;
        grenadeThrower.Throw();

        onAmmoShotListener.OnAmmoShot(transform);

        isGrenadeFlying = true;
    }

    public void OnGrenadeDestroy()
    {
        collisionHandler.HandleCollision(new ExplosionCollisionContextFactory(transform.position, radius, damage).Create());
        gameObject.SetActive(false);
    }

}
