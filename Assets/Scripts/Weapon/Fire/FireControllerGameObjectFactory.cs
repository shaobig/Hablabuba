using System.Collections.Generic;
using UnityEngine;

public class FireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<FireController>
{
    [SerializeField]
    private BazookaFireControllerGameObjectFactory bazookaFireControllerGameObjectFactory;
    [SerializeField]
    private RifleFireControllerGameObjectFactory rifleFireControllerGameObjectFactory;
    [SerializeField]
    private InitGrenadeFireControllerGameObjectFactory initGrenadeFireControllerGameObjectFactory;
    private WeaponType weaponType;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener)
    {
        rifleFireControllerGameObjectFactory.Init(onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
        bazookaFireControllerGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
        initGrenadeFireControllerGameObjectFactory.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, onSetCameraOnObjectListener, onAmmoCollideListener);
    }

    public FireController Create(GameObject weaponPrefab, Transform holdPoint)
    {
        return weaponType switch
        {
            WeaponType.RIFLE => rifleFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            WeaponType.BAZOOKA => bazookaFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            WeaponType.GRENADE => initGrenadeFireControllerGameObjectFactory.Create(weaponPrefab, holdPoint),
            _ => throw new System.NotImplementedException($"The fire controller for the {weaponType} type is not supported!"),
        };
    }

    public WeaponType WeaponType
    {
        set => weaponType = value;
    }

}
