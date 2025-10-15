using UnityEngine;

public class WeaponController : MonoBehaviour, Activator, Deactivator, WeaponHolder, WeaponHider, FireController
{
    [SerializeField]
    private FireControllerCreator fireControllerCreator;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private WeaponTurner weaponTurner;
    [SerializeField]
    private Transform holdPoint;
    private FireController fireController;
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
        fireControllerCreator.WeaponItem = weaponItem;
        fireController = fireControllerCreator.Create(weaponItem.Prefab, holdPoint);

        isWeaponHeld = true;
    }

    public void HideWeapon()
    {
        gameObjectRemover.Remove(holdPoint.GetChild(0).gameObject);
        isWeaponHeld = false;
    }

    public void Fire()
    {
        if (enabled)
        {
            fireController.Fire();
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

    public OnAmmoShotListener OnAmmoShotListener
    {
        set => fireControllerCreator.OnAmmoShotListener = value;
    }

    public OnBulletCollideListener OnBulletCollideListener
    {
        set => fireControllerCreator.OnBulletCollideListener = value;
    }

    public OnSetCameraOnShotPlayerListener OnSetOnShotPlayerCameraListener
    {
        set => fireControllerCreator.OnSetCameraOnShotPlayerListener = value;
    }

}
