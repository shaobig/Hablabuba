using UnityEngine;

public class GrenadeFireController : MonoBehaviour, FireController,
    OnTimerCountListener, OnTimerFinishListener, OnGrenadeDestroyListener
{
    [SerializeField]
    private WeaponTimer weaponTimer;
    [SerializeField]
    private GrenadeThrower grenadeThrower;
    [SerializeField]
    private float force = 5f;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;

    public void Init(
        WeaponItem weaponItem,
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener
        )
    {
        this.weaponItem = weaponItem;
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;

        weaponTimer.Init(this, this);
        grenadeThrower.Init(GetComponent<Rigidbody>(), this);
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
            onFireListener.OnFire(weaponItem.Weapon.Type);
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
    }

    public void OnGrenadeDestroy()
    {
        Destroy(gameObject);
    }

}
