using System;
using System.Collections.Generic;
using Unity.Cinemachine;

public class ListGameCameraActivatorFactory : CameraActivatorFactory
{
    private readonly List<CinemachineCamera> cameraList;
    private readonly CinemachineCamera activeCamera;

    public ListGameCameraActivatorFactory(List<CinemachineCamera> cameraList, CinemachineCamera activeCamera)
    {
        this.cameraList = cameraList;
        this.activeCamera = activeCamera;
    }

    public CameraActivator Create()
    {
        Dictionary<CameraType, CinemachineCamera> cameraDictionary = new();
        Queue<CinemachineCamera> cameraQueue = new(cameraList);

        var cameraTypeList = (CameraType[])Enum.GetValues(typeof(CameraType));

        foreach (var cameraType in cameraTypeList)
        {
            cameraDictionary.Add(cameraType, cameraQueue.Dequeue());
        }

        return new GameCameraActivatorFactory(cameraDictionary, activeCamera).Create();
    }
    
}
