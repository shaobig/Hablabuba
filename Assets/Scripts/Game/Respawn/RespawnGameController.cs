using System.Collections.Generic;
using UnityEngine;

public class RespawnGameController : MonoBehaviour, Respawner
{
    [SerializeField]
    private DatabasePlayerRespawner playerRespawner;

    public List<PlayerController> Respawn()
    {
        return playerRespawner.Respawn();
    }

}
