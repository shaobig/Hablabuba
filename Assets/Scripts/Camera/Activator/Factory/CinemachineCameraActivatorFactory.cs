using System.Collections.Generic;
using Unity.Cinemachine;

public class CinemachineCameraActivatorFactory : CameraActivatorFactory
{
    private readonly Dictionary<CameraType, CinemachineCamera> cameraDictionary;
    private readonly CinemachineCamera activeCamera;

    public CinemachineCameraActivatorFactory(Dictionary<CameraType, CinemachineCamera> cameraDictionary, CinemachineCamera activeCamera)
    {
        this.cameraDictionary = cameraDictionary;
        this.activeCamera = activeCamera;
    }

    public CameraActivator Create()
    {
        return new CinemachineCameraActivator(cameraDictionary, activeCamera);
    }

}
