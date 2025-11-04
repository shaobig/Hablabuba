using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ShotCameraController : MonoBehaviour,
    OnSetCameraOnObjectListener<List<PlayerController>>
{
    [SerializeField]
    private float minFocusTime = 2f;
    [SerializeField]
    private float maxFocusTime = 5f;
    private CinemachineCamera shotCamera;
    private List<PlayerController> playerList;
    private OnNextStepPreparedListener onNextStepPreparedListener;

    public void Init(
        CinemachineCamera shotCamera,
        List<PlayerController> playerList,
        OnNextStepPreparedListener onNextStepPreparedListener)
    {
        this.shotCamera = shotCamera;
        this.playerList = playerList;
        this.onNextStepPreparedListener = onNextStepPreparedListener;
    }

    public void OnSetCameraOnObjectList(List<PlayerController> shotPlayerList)
    {
        StartCoroutine(SetCameraOnPlayerList(shotPlayerList));
    }

    IEnumerator SetCameraOnPlayerList(List<PlayerController> shotPlayerList)
    {
        playerList.ForEach(player => player.Camera = shotCamera.transform);

        foreach (var shotPlayer in shotPlayerList)
        {
            shotCamera.Follow = shotPlayer.transform;

            yield return new WaitForEndOfFrame();

            playerList.ForEach(player => player.RefreshDisplay());
            yield return new WaitForSeconds(Mathf.Clamp(maxFocusTime / shotPlayerList.Count, minFocusTime, maxFocusTime));
        }

        onNextStepPreparedListener.OnNextStepPrepared();
    }

}
