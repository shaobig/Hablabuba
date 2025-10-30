using System.Collections.Generic;
using UnityEngine;

public class WeaponTypeDictionaryAngleDefiner : MonoBehaviour, AngleDefiner
{
    private Dictionary<WeaponType, int> weaponTypeAngleDictionary = new()
    {
        { WeaponType.RIFLE, -15 },
        { WeaponType.BAZOOKA, -45 },
        { WeaponType.GRENADE, -45 },
    };

    public int DefineAngle(WeaponType weaponType)
    {
        return weaponTypeAngleDictionary[weaponType];
    }

}
