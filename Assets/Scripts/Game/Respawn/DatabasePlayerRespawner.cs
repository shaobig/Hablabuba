using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabasePlayerRespawner : MonoBehaviour, Respawner
{
    [SerializeField]
    private PlayerPrefabDatabaseReader playerPrefabDatabaseReader;
    [SerializeField]
    private InitPlayerControllerCreator initPlayerControllerCreator;
    [SerializeField]
    private List<Transform> respawnPointList;

    public List<PlayerController> Respawn()
    {
        Queue<Transform> respawnQueue = new(respawnPointList);

        return playerPrefabDatabaseReader.ReadDatabase()
            .Take(respawnQueue.Count)
            .Select(playerPrefab =>
            {
                initPlayerControllerCreator.Player = playerPrefab.Player;
                return initPlayerControllerCreator.Create(playerPrefab.Prefab, respawnQueue.Dequeue());
            })
            .ToList();
    }

}
