using System;
using System.Collections.Generic;
using Unity.Cinemachine;

public class CinemachineCameraDictionaryFactory : DictionaryFactory<CameraType, CinemachineCamera>
{
    private List<CinemachineCamera> cameraList;

    public CinemachineCameraDictionaryFactory(List<CinemachineCamera> cameraList)
    {
        this.cameraList = cameraList;
    }

    public Dictionary<CameraType, CinemachineCamera> Create()
    {
        Dictionary<CameraType, CinemachineCamera> cameraDictionary = new();
        Queue<CinemachineCamera> cameraQueue = new(cameraList);

        var cameraTypeList = (CameraType[]) Enum.GetValues(typeof(CameraType));

        foreach (var cameraType in cameraTypeList)
        {
            cameraDictionary.Add(cameraType, cameraQueue.Dequeue());
        }

        return cameraDictionary;
    }

}
