using System.Collections.Generic;
using UnityEngine;

public class WeaponProgressBarGameController : MonoBehaviour,
    OnSelectWeaponListener, OnFireListener,
    OnWeaponProgressBarChangeValueListener
{
    private readonly List<WeaponType> SUPPORT_WEAPON_TYPES = new() { WeaponType.BAZOOKA, WeaponType.GRENADE };

    [SerializeField]
    private WeaponProgressBarControllerGameObjectFactory weaponProgressBarControllerGameObjectFactory;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private GameObject progressBarPrefab;
    private WeaponProgressBarController weaponProgressBarController;
    private Transform canvas;

    public void Init(Transform canvas)
    {
        this.canvas = canvas;
    }

    public void OnSelectWeapon(WeaponType weaponType)
    {
        if (weaponProgressBarController == null && SUPPORT_WEAPON_TYPES.Contains(weaponType))
        {
            weaponProgressBarController = weaponProgressBarControllerGameObjectFactory.Create(progressBarPrefab, canvas);
            weaponProgressBarController.Init();
        }
        else if (weaponProgressBarController != null && !SUPPORT_WEAPON_TYPES.Contains(weaponType))
        {
            gameObjectRemover.Remove(weaponProgressBarController.gameObject);
        }
    }

    public void OnFire(WeaponType weaponType)
    {
        if (weaponProgressBarController != null && (WeaponType.BAZOOKA.Equals(weaponType) || WeaponType.GRENADE.Equals(weaponType)))
        {
            gameObjectRemover.Remove(weaponProgressBarController.gameObject);
        }
    }

    public void OnWeaponProgressBarChangeValue(float value)
    {
        weaponProgressBarController.OnWeaponProgressBarChangeValue(value);
    }

}
