using System.Collections.Generic;
using Unity.Cinemachine;

public class ListCinemachineCameraActivatorFactory : CameraActivatorFactory
{
    private List<CinemachineCamera> cameraList;

    public ListCinemachineCameraActivatorFactory(List<CinemachineCamera> cameraList)
    {
        this.cameraList = cameraList;
    }

    public CameraActivator Create()
    {
        return new CinemachineCameraActivatorFactory(new CinemachineCameraDictionaryFactory(cameraList).Create(), cameraList[0]).Create();
    }

}
