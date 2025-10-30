using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabasePlayerRespawner : MonoBehaviour, Respawner
{
    [SerializeField]
    private PlayerPrefabDatabaseReader playerPrefabDatabaseReader;
    [SerializeField]
    private InitPlayerControllerGameObjectFactory initPlayerControllerGameObjectFactory;
    [SerializeField]
    private List<Transform> respawnPointList;

    public List<PlayerController> Respawn()
    {
        Queue<Transform> respawnQueue = new(respawnPointList);

        return playerPrefabDatabaseReader.ReadDatabase()
            .Take(respawnQueue.Count)
            .Select(playerPrefab =>
            {
                initPlayerControllerGameObjectFactory.Player = playerPrefab.Player;
                return initPlayerControllerGameObjectFactory.Create(playerPrefab.Prefab, respawnQueue.Dequeue());
            })
            .ToList();
    }

}
