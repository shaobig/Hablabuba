using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabaseReader : MonoBehaviour, DatabaseReader<WeaponPrefab>
{
    [SerializeField]
    private WeaponPrefabDatabase weaponPrefabDatabase;

    public List<WeaponPrefab> ReadDatabase()
    {
        return weaponPrefabDatabase.WeaponPrefabList;
    }

}
