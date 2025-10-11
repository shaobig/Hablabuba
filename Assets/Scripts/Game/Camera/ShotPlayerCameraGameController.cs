using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerCameraGameController : MonoBehaviour,
    OnSetCameraOnShotPlayerListener
{
    [SerializeField]
    private int focusTime = 5;
    private Camera shotPlayerCamera;
    private CameraController cameraController;
    private OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener;

    public void Init(Camera shotPlayerCamera, OnSetCameraOnShotPlayerCompleteListener onSetCameraOnShotPlayerCompleteListener)
    {
        this.shotPlayerCamera = shotPlayerCamera;
        this.onSetCameraOnShotPlayerCompleteListener = onSetCameraOnShotPlayerCompleteListener;

        shotPlayerCamera.enabled = false;
        cameraController = shotPlayerCamera.GetComponent<CameraController>();
        cameraController.Deactivate();
    }

    public void OnSetCameraOnShotPlayer(List<PlayerController> playerList)
    {
        if (playerList.Count != 0)
        {
            shotPlayerCamera.enabled = true;
            cameraController.Activate();    

            StartCoroutine(SetCameraOnPlayerList(playerList));
        }
    }

    IEnumerator SetCameraOnPlayerList(List<PlayerController> playerList)
    {
        foreach (var player in playerList)
        {
            cameraController.Target = player.transform;
            yield return new WaitForSeconds(focusTime / playerList.Count);
        }

        shotPlayerCamera.enabled = false;
        cameraController.Deactivate();
        onSetCameraOnShotPlayerCompleteListener.OnSetCameraOnShotPlayerComplete();
    }

}
