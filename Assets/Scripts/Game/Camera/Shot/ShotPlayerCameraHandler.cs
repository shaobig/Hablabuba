using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerCameraHandler : MonoBehaviour,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private float minFocusTime = 2f;
    [SerializeField]
    private float maxFocusTime = 5f;
    private Camera shotPlayerCamera;
    private CameraController cameraController;
    private List<PlayerController> playerList;
    private OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener;

    public void Init(Camera shotPlayerCamera, CameraController cameraController, List<PlayerController> playerList, OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        this.shotPlayerCamera = shotPlayerCamera;
        this.cameraController = cameraController;
        this.playerList = playerList;
        this.onSetCameraOnShotPlayerCompleteListener = onSetCameraOnShotPlayerCompleteListener;
    }

    public void Activate()
    {
        shotPlayerCamera.enabled = true;
        cameraController.Activate();
    }

    public void Deactivate()
    {
        shotPlayerCamera.enabled = false;
        cameraController.Deactivate();
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
            cameraController.Target = shotPlayer.transform;

            yield return new WaitForEndOfFrame();

            playerList.ForEach(player => player.RefreshDisplay());
            yield return new WaitForSeconds(Mathf.Clamp(maxFocusTime / shotPlayerList.Count, minFocusTime, maxFocusTime));
        }

        shotPlayerCamera.enabled = false;
        cameraController.Deactivate();

        onSetCameraOnShotPlayerCompleteListener.OnSetCameraOnShotPlayerComplete();
    }

}
