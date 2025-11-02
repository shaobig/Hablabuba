using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ShotObjectCameraController : MonoBehaviour,
    OnSetCameraOnObjectListener<List<PlayerController>>
{
    [SerializeField]
    private float minFocusTime = 2f;
    [SerializeField]
    private float maxFocusTime = 5f;
    private CinemachineCamera shotObjectCamera;
    private List<PlayerController> playerList;
    private OnSetCameraOnObjectCompleteListener onSetCameraOnObjectListenerCompleteListener;

    public void Init(
        CinemachineCamera shotObjectCamera,
        List<PlayerController> playerList,
        OnSetCameraOnObjectCompleteListener onSetCameraOnObjectListenerCompleteListener)
    {
        this.shotObjectCamera = shotObjectCamera;
        this.playerList = playerList;
        this.onSetCameraOnObjectListenerCompleteListener = onSetCameraOnObjectListenerCompleteListener;
    }

    public void OnSetCameraOnObjectList(List<PlayerController> shotPlayerList)
    {
        StartCoroutine(SetCameraOnPlayerList(shotPlayerList));
    }

    IEnumerator SetCameraOnPlayerList(List<PlayerController> shotPlayerList)
    {
        playerList.ForEach(player => player.Camera = shotObjectCamera.transform);

        foreach (var shotPlayer in shotPlayerList)
        {
            shotObjectCamera.Follow = shotPlayer.transform;

            yield return new WaitForEndOfFrame();

            playerList.ForEach(player => player.RefreshDisplay());
            yield return new WaitForSeconds(Mathf.Clamp(maxFocusTime / shotPlayerList.Count, minFocusTime, maxFocusTime));
        }
        
        onSetCameraOnObjectListenerCompleteListener.OnSetCameraOnObjectComplete();
    }

}
