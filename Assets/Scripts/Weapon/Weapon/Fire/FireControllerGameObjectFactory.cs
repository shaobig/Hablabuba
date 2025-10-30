using UnityEngine;

public class FireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<FireController>
{
    [SerializeField]
    private BazookaFireControllerGameObjectFactory bazookaFireControllerGameObjectFactory;
    [SerializeField]
    private RifleFireControllerGameObjectFactory rifleFireControllerGameObjectFactory;
    [SerializeField]
    private InitGrenadeFireControllerGameObjectFactory initGrenadeFireControllerGameObjectFactory;
    private WeaponItem weaponItem;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        rifleFireControllerGameObjectFactory.Init(onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
        bazookaFireControllerGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
        initGrenadeFireControllerGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnShotPlayerListener, onAmmoCollideListener);
    }

    public FireController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        return weaponItem.Weapon.Type switch
        {
            WeaponType.RIFLE => rifleFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            WeaponType.BAZOOKA => bazookaFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            WeaponType.GRENADE => initGrenadeFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            _ => throw new System.NotImplementedException($"The fire controller for the {weaponItem.Weapon.Type} type is not supported!"),
        };
    }

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            initGrenadeFireControllerGameObjectFactory.WeaponItem = value;
        }
    }

}
