using UnityEngine;

public class GrenadeFireController : MonoBehaviour, FireController
{
    [SerializeField]
    private GrenadeThrower grenadeThrower;
    private WeaponItem weaponItem;
    private OnAmmoShotListener onAmmoShotListener;

    public void Init(
        WeaponItem weaponItem,
        OnAmmoShotListener onAmmoShotListener
        )
    {
        this.weaponItem = weaponItem;
        this.onAmmoShotListener = onAmmoShotListener;

        grenadeThrower.Init(GetComponent<Rigidbody>());
    }

    public void Fire(FireAction fireAction)
    {
        if (FireAction.STOP.Equals(fireAction))
        {
            grenadeThrower.Throw();
            onAmmoShotListener.OnAmmoShot(transform);
        }
    }

}
