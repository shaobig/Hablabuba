using System.Collections.Generic;
using Unity.Cinemachine;

public class ListBlockCameraActivatorFactory : CameraActivatorFactory
{
    private List<CinemachineCamera> cameraList;

    public ListBlockCameraActivatorFactory(List<CinemachineCamera> cameraList)
    {
        this.cameraList = cameraList;
    }

    public CameraActivator Create()
    {
        return new BlockCameraActivatorFactory(new BlockCameraDictionaryFactory().Create(), new ListCinemachineCameraActivatorFactory(cameraList).Create(), CameraType.PLAYER).Create();
    }

}
