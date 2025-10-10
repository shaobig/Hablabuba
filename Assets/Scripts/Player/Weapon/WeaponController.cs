using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, Emitter
{
    [SerializeField]
    private InitWeaponFireControllerCreator weaponFireControllerCreator;
    [SerializeField]
    private WeaponTurner weaponTurner;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private Transform holdPoint;
    private WeaponFireController weaponFireController;
    private WeaponItem weaponItem;
    private bool isWeaponHeld;

    public void Init()
    {
        weaponTurner.Init(holdPoint);
    }

    void FixedUpdate()
    {
        if (isWeaponHeld)
        {
            weaponTurner.ScrollDownDelta = Input.GetAxis("Mouse ScrollWheel");
            weaponTurner.Turn();
        }
    }

    public void HoldWeapon()
    {
        weaponFireControllerCreator.Init(weaponItem.Weapon);
        weaponFireController = weaponFireControllerCreator.Create(weaponItem.Prefab, holdPoint);

        isWeaponHeld = true;
    }

    public void HideWeapon()
    {
        gameObjectRemover.Remove(weaponFireController.gameObject);
        isWeaponHeld = false;
    }

    public void Emit()
    {
        if (enabled)
        {
            weaponFireController.Emit();
        }
    }

    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

    public bool IsWeaponHeld => isWeaponHeld;

    public WeaponItem Weapon
    {
        get => weaponItem;
        set => weaponItem = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        set => weaponFireControllerCreator.OnBulletCollideListener = value;
    }

}
