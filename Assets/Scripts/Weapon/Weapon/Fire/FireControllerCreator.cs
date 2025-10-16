using UnityEngine;

public class FireControllerCreator : MonoBehaviour, Creator<FireController>
{
    [SerializeField]
    private BazookaFireControllerCreator bazookaFireControllerCreator;
    [SerializeField]
    private RiffleFireControllerCreator riffleFireControllerCreator;
    private WeaponItem weaponItem;

    public void Init(OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener)
    {
        bazookaFireControllerCreator.Init(onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
        riffleFireControllerCreator.Init(onAmmoShotListener, onBulletCollideListener, onSetCameraOnShotPlayerListener);
    }

    public FireController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        if (WeaponType.BAZOOKA.Equals(weaponItem.Weapon.WeaponType))
        {
            return bazookaFireControllerCreator.Create(weaponPrefab, holdPoint);
        }
        else
        {
            return riffleFireControllerCreator.Create(weaponPrefab, holdPoint);
        }
    }

    public WeaponItem WeaponItem
    {
        set
        {
            weaponItem = value;
            bazookaFireControllerCreator.WeaponItem = value;
            riffleFireControllerCreator.WeaponItem = value;
        }
    }

}
