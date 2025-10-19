using UnityEngine;

public class InitGrenadeFireControllerCreator : MonoBehaviour, Creator<GrenadeFireController>
{
    [SerializeField]
    private GrenadeFireControllerCreator grenadeFireControllerCreator;
    private WeaponItem weaponItem;
    private OnAmmoShotListener onAmmoShotListener;

    public void Init(OnAmmoShotListener onAmmoShotListener)
    {
        this.onAmmoShotListener = onAmmoShotListener;
    }

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        var grenadeFireController = grenadeFireControllerCreator.Create(prefab, target);
        grenadeFireController.Init(weaponItem, onAmmoShotListener);

        return grenadeFireController;
    }

    public WeaponItem WeaponItem
    {
        set => weaponItem = value;
    }

}
