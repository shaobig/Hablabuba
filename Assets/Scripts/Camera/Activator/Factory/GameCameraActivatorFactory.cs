using System.Collections.Generic;
using Unity.Cinemachine;

public class GameCameraActivatorFactory : CameraActivatorFactory
{
    private readonly Dictionary<CameraType, CinemachineCamera> cameraDictionary;
    private readonly CinemachineCamera activeCamera;

    public GameCameraActivatorFactory(Dictionary<CameraType, CinemachineCamera> cameraDictionary, CinemachineCamera activeCamera)
    {
        this.cameraDictionary = cameraDictionary;
        this.activeCamera = activeCamera;
    }

    public CameraActivator Create()
    {
        return new GameCameraActivator(cameraDictionary, activeCamera);
    }

}
