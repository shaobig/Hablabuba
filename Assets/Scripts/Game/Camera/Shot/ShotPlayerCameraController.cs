using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ShotPlayerCameraController : MonoBehaviour,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private float minFocusTime = 2f;
    [SerializeField]
    private float maxFocusTime = 5f;
    private CinemachineCamera shotPlayerCamera;
    private List<PlayerController> playerList;
    private OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener;

    public void Init(
        CinemachineCamera shotPlayerCamera,
        List<PlayerController> playerList,
        OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        this.shotPlayerCamera = shotPlayerCamera;
        this.playerList = playerList;
        this.onSetCameraOnShotPlayerCompleteListener = onSetCameraOnShotPlayerCompleteListener;
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        StartCoroutine(SetCameraOnPlayerList(playerList));
    }

    IEnumerator SetCameraOnPlayerList(List<PlayerController> shotPlayerList)
    {
        playerList.ForEach(player => player.Camera = shotPlayerCamera.transform);

        foreach (var shotPlayer in shotPlayerList)
        {
            shotPlayerCamera.Follow = shotPlayer.transform;

            yield return new WaitForEndOfFrame();

            playerList.ForEach(player => player.RefreshDisplay());
            yield return new WaitForSeconds(Mathf.Clamp(maxFocusTime / shotPlayerList.Count, minFocusTime, maxFocusTime));
        }
        
        onSetCameraOnShotPlayerCompleteListener.OnSetCameraOnShotPlayerComplete();
    }

}
