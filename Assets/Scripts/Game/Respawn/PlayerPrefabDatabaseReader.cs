using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabDatabaseReader : MonoBehaviour, DatabaseReader<PlayerPrefab>
{
    [SerializeField]
    private PlayerPrefabDatabase playerPrefabDatabase;

    public List<PlayerPrefab> ReadDatabase()
    {
        return playerPrefabDatabase.PlayerPrefabList;
    }

}
