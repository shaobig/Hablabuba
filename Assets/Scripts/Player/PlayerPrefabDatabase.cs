using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPrefabDatabase", menuName = "Game/Player/Database")]
public class PlayerPrefabDatabase : ScriptableObject
{
    [SerializeField]
    private List<PlayerPrefab> playerPrefabList;

    public List<PlayerPrefab> PlayerPrefabList => playerPrefabList;
}
