using UnityEngine;

public class FireControllerCreator : MonoBehaviour, Creator<FireController>
{
    [SerializeField]
    private BazookaFireControllerCreator bazookaFireControllerCreator;
    [SerializeField]
    private RiffleFireControllerCreator riffleFireControllerCreator;
    private WeaponItem weaponItem;

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

    public OnAmmoShotListener OnAmmoShotListener
    {
        set
        {
            bazookaFireControllerCreator.OnAmmoShotListener = value;
            riffleFireControllerCreator.OnAmmoShotListener = value;
        }
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        set
        {
            bazookaFireControllerCreator.OnBulletCollideListener = value;
            riffleFireControllerCreator.OnBulletCollideListener = value;
        }
    }

    public OnSetCameraOnShotPlayerListener OnSetCameraOnShotPlayerListener
    {
        set
        {
            bazookaFireControllerCreator.OnSetCameraOnShotPlayerListener = value;
            riffleFireControllerCreator.OnSetCameraOnShotPlayerListener = value;
        }
    }

}
