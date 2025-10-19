using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerListDisplayRefresher playerListDisplayRefresher;
    private CinemachineCamera playerCamera;

    public void Init(CinemachineCamera playerCamera, List<PlayerController> playerList)
    {
        this.playerCamera = playerCamera;

        playerListDisplayRefresher.Init(playerCamera.transform, playerList);
    }

    void LateUpdate()
    {
        if (playerCamera.enabled)
        {
            playerListDisplayRefresher.RefreshDisplay();
        }
    }

    public void Follow(Transform target)
    {
        playerCamera.Follow = target;
    }

}
