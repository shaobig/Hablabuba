using UnityEngine;

public class FireControllerCreator : MonoBehaviour, Creator<FireController>
{
    [SerializeField]
    private BazookaFireControllerCreator bazookaFireControllerCreator;
    [SerializeField]
    private RiffleFireControllerCreator riffleFireControllerCreator;
    [SerializeField]
    private InitGrenadeFireControllerCreator initGrenadeFireControllerCreator;
    private WeaponItem weaponItem;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnBulletCollideListener onBulletCollideListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        riffleFireControllerCreator.Init(onFireListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
        bazookaFireControllerCreator.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
        initGrenadeFireControllerCreator.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener);
    }

    public FireController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        return weaponItem.Weapon.Type switch
        {
            WeaponType.RIFFLE => riffleFireControllerCreator.Create(weaponPrefab, holdPoint),
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
            riffleFireControllerCreator.WeaponItem = value;
            bazookaFireControllerCreator.WeaponItem = value;
            initGrenadeFireControllerCreator.WeaponItem = value;
        }
    }

}
