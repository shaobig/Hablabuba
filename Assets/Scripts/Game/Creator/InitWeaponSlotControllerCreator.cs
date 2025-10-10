using UnityEngine;

public class InitWeaponSlotControllerCreator : MonoBehaviour, Creator<WeaponSlotController>
{
    [SerializeField]
    private WeaponSlotControllerCreator weaponSlotControllerCreator;
    private WeaponItem weaponItem;

    public WeaponSlotController Create(GameObject prefab, Transform target)
    {
        var weaponSlotCreator = weaponSlotControllerCreator.Create(prefab, target);
        weaponSlotCreator.Init(weaponItem.Sprite, weaponItem.Amount.ToString());

        return weaponSlotCreator;
    }

    public WeaponItem WeaponItem
    {
        get => weaponItem;
        set => weaponItem = value;
    }

}
