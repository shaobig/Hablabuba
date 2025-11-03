using System.Collections.Generic;
using Unity.Cinemachine;

public class GameCameraActivator : CameraActivator
{
    private const int INACTIVE_CAMERA_PRIORITY = 0;
    private const int ACTIVE_CAMERA_PRIORITY = 1;

    private Dictionary<CameraType, CinemachineCamera> cameraDictionary;
    private CinemachineCamera activeCamera;

    public GameCameraActivator(Dictionary<CameraType, CinemachineCamera> cameraDictionary, CinemachineCamera activeCamera)
    {
        this.cameraDictionary = cameraDictionary;
        this.activeCamera = activeCamera;
    }

    public void ActivateCamera(CameraType cameraType)
    {
        activeCamera.Priority = INACTIVE_CAMERA_PRIORITY;

        activeCamera = cameraDictionary[cameraType];
        activeCamera.Priority = ACTIVE_CAMERA_PRIORITY;
    }

}
