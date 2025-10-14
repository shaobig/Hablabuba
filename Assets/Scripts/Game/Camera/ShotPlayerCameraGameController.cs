using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerCameraGameController : MonoBehaviour, Activator, Deactivator,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private int focusTime = 5;
    private Camera shotPlayerCamera;
    private CameraController cameraController;
    private OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener;
    private List<PlayerController> playerList;

    public void Init(Camera shotPlayerCamera, List<PlayerController> playerList, OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        this.playerList = playerList;

        this.shotPlayerCamera = shotPlayerCamera;
        this.onSetCameraOnShotPlayerCompleteListener = onSetCameraOnShotPlayerCompleteListener;

        shotPlayerCamera.enabled = false;
        cameraController = shotPlayerCamera.GetComponent<CameraController>();
        cameraController.Deactivate();
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
        if (playerList.Count != 0)
        {
            StartCoroutine(SetCameraOnPlayerList(playerList));
        }
    }

    IEnumerator SetCameraOnPlayerList(List<PlayerController> shotPlayerList)
    {
        playerList.ForEach(player => player.Camera = shotPlayerCamera.transform);

        foreach (var shotPlayer in shotPlayerList)
        {
            cameraController.Target = shotPlayer.transform;

            yield return new WaitForEndOfFrame();

            playerList.ForEach(player => player.RefreshDisplay());
            yield return new WaitForSeconds(focusTime / shotPlayerList.Count);
        }

        shotPlayerCamera.enabled = false;
        cameraController.Deactivate();
        
        onSetCameraOnShotPlayerCompleteListener.OnSetCameraOnShotPlayerComplete();
    }

}
