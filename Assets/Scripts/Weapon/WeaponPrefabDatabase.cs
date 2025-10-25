using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPrefabDatabase", menuName = "Game/Weapon/Database")]
public class WeaponPrefabDatabase : ScriptableObject
{
    [SerializeField]
    private List<WeaponPrefab> weaponPrefabList;

    public List<WeaponPrefab> WeaponPrefabList => weaponPrefabList;
}
