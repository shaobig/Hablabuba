using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ShotPlayerCameraController : MonoBehaviour,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private ShotPlayerCameraHandler shotPlayerCameraHandler;

    public void Init(
        CinemachineCamera shotPlayerCamera,
        List<PlayerController> playerList,
        OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        // shotPlayerCameraHandler.Init(shotPlayerCamera)
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        shotPlayerCameraHandler.OnSetCameraOnShotPlayer(playerList);
    }

}
