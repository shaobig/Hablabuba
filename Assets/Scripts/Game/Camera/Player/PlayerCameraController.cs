using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
   private CinemachineCamera playerCamera;

    public void Init(CinemachineCamera playerCamera, List<PlayerController> playerList)
    {
        this.playerCamera = playerCamera;
    }

    // void LateUpdate()
    // {
    //     if (playerCamera.enabled)
    //     {
    //         playerListDisplayRefresher.RefreshDisplay();
    //     }
    // }

    public void Follow(Transform target)
    {
        playerCamera.Follow = target;
    }

}
