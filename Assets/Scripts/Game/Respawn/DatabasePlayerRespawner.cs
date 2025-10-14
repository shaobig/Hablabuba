using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabasePlayerRespawner : MonoBehaviour, Respawner
{
    [SerializeField]
    private PlayerPrefabDatabase playerPrefabDatabase;
    [SerializeField]
    private InitPlayerControllerCreator playerControllerCreator;
    [SerializeField]
    private WindowControllerCreator windowControllerCreator;
    [SerializeField]
    private GameObject inventoryPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private List<Transform> respawnPointList;

    public List<PlayerController> Respawn()
    {
        Queue<Transform> respawnQueue = new(respawnPointList);

        WindowController windowController = windowControllerCreator.Create(inventoryPrefab, canvasTransform);
        playerControllerCreator.WindowController = windowController;

        return playerPrefabDatabase.PlayerPrefabList
            .Take(respawnQueue.Count)
            .Select(prefab =>
            {
                playerControllerCreator.Player = prefab.Player;
                return playerControllerCreator.Create(prefab.Prefab, respawnQueue.Dequeue());
            })
            .ToList();
    }

}
