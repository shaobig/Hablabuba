using UnityEngine;

public class FireControllerCreator : MonoBehaviour, Creator<FireController>
{
    [SerializeField]
    private BazookaFireControllerCreator bazookaFireControllerCreator;
    [SerializeField]
    private RifleFireControllerCreator rifleFireControllerCreator;
    [SerializeField]
    private InitGrenadeFireControllerCreator initGrenadeFireControllerCreator;
    private WeaponItem weaponItem;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        rifleFireControllerCreator.Init(onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
        bazookaFireControllerCreator.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
        initGrenadeFireControllerCreator.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
    }

    public FireController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        return weaponItem.Weapon.Type switch
        {
            WeaponType.RIFLE => rifleFireControllerCreator.Create(weaponPrefab, holdPoint),
            WeaponType.BAZOOKA => bazookaFireControllerCreator.Create(weaponPrefab, holdPoint),
            WeaponType.GRENADE => initGrenadeFireControllerCreator.Create(weaponPrefab, holdPoint),
            _ => throw new System.NotImplementedException($"The fire controller for the {weaponItem.Weapon.Type} type is not supported!"),
        };
    }

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            initGrenadeFireControllerCreator.WeaponItem = value;
        }
    }

}
