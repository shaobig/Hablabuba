using System.Collections.Generic;
using UnityEngine;

public class ShootControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AimShootController>
{
    [SerializeField]
    private BazookaShootControllerGameObjectFactory bazookaShooterGameObjectFactory;
    [SerializeField]
    private RifleFireControllerGameObjectFactory rifleShooterGameObjectFactory;
    [SerializeField]
    private InitGrenadeShooterGameObjectFactory initGrenadeShooterGameObjectFactory;
    private WeaponType weaponType;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener)
    {
        rifleShooterGameObjectFactory.Init(onAimTakenListener, onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
        bazookaShooterGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
        initGrenadeShooterGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
    }

    public AimShootController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        return weaponType switch
        {
            WeaponType.RIFLE => rifleShooterGameObjectFactory.Create(weaponPrefab, holdPoint),
            // WeaponType.BAZOOKA => bazookaShooterGameObjectFactory.Create(weaponPrefab, holdPoint),
            // WeaponType.GRENADE => initGrenadeShooterGameObjectFactory.Create(weaponPrefab, holdPoint),
            _ => throw new System.NotImplementedException($"The fire controller for the {weaponType} type is not supported!"),
        };
    }

    public WeaponType WeaponType
    {
        set => weaponType = value;
    }

}
