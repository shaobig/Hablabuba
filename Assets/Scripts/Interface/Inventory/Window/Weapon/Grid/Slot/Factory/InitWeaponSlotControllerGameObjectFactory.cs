using UnityEngine;

public class InitWeaponSlotControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WeaponSlotController>
{
    [SerializeField]
    private WeaponSlotControllerGameObjectFactory weaponSlotControllerGameObjectFactory;
    private WeaponItem weaponItem;

    public WeaponSlotController Create(GameObject prefab, Transform target)
    {
        var weaponSlotCreator = weaponSlotControllerGameObjectFactory.Create(prefab, target);
        weaponSlotCreator.Init(weaponItem.Sprite, weaponItem.Amount.ToString());

        return weaponSlotCreator;
    }

    public WeaponItem WeaponItem
    {
        set => weaponItem = value;
    }

}
