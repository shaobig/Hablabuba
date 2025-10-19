using UnityEngine;

public class InitGrenadeFireControllerCreator : MonoBehaviour, Creator<GrenadeFireController>
{
    [SerializeField]
    private GrenadeFireControllerCreator grenadeFireControllerCreator;
    private WeaponItem weaponItem;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
    }

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        var grenadeFireController = grenadeFireControllerCreator.Create(prefab, target);
        grenadeFireController.Init(weaponItem, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener);

        return grenadeFireController;
    }

    public WeaponItem WeaponItem
    {
        set => weaponItem = value;
    }

}
