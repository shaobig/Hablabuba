using UnityEngine;

public class InitWeaponFireControllerCreator : MonoBehaviour, Creator<WeaponFireController>
{
    [SerializeField]
    private WeaponFireControllerCreator weaponFireControllerCreator;
    private Weapon weapon;
    private OnAmmoShotListener onAmmoShotListener;
    private OnBulletCollideListener onBulletCollideListener;
    private OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener;

    public void Init(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public WeaponFireController Create(GameObject gameObject, Transform target)
    {
        var weaponFireController = weaponFireControllerCreator.Create(gameObject, target);
        weaponFireController.Init(weapon, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);

        return weaponFireController;
    }

    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    public OnAmmoShotListener OnAmmoShotListener
    {
        get => onAmmoShotListener;
        set => onAmmoShotListener = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        get => onBulletCollideListener;
        set => onBulletCollideListener = value;
    }

    public OnSetCameraOnShotPlayerListener OnSetOnShotPlayerCameraListener
    {
        get => onSetOnShotPlayerCameraListener;
        set => onSetOnShotPlayerCameraListener = value;
    }

}
