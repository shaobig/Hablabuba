using UnityEngine;

public class InitWeaponFireControllerCreator : MonoBehaviour, Creator<WeaponFireController>
{
    [SerializeField]
    private WeaponFireControllerCreator weaponFireControllerCreator;
    private Weapon weapon;
    private OnBulletCollideListener onBulletCollideListener;

    public void Init(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public WeaponFireController Create(GameObject gameObject, Transform target)
    {
        var weaponFireController = weaponFireControllerCreator.Create(gameObject, target);
        weaponFireController.Init(weapon, onBulletCollideListener);

        return weaponFireController;
    }

    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        get => onBulletCollideListener;
        set => onBulletCollideListener = value;
    }

}
