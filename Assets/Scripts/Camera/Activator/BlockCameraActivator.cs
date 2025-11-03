using System.Collections.Generic;

public class BlockCameraActivator : CameraActivator
{
    private Dictionary<CameraType, CameraType> blockingDictionary;
    private CameraActivator cameraActivator;
    private CameraType currentType;

    public BlockCameraActivator(Dictionary<CameraType, CameraType> blockingDictionary, CameraActivator cameraActivator, CameraType currentType)
    {
        this.blockingDictionary = blockingDictionary;
        this.cameraActivator = cameraActivator;
        this.currentType = currentType;
    }

    public void ActivateCamera(CameraType cameraType)
    {
        if (blockingDictionary.TryGetValue(currentType, out var blockedType) && blockedType.Equals(cameraType))
        {
            return;
        }

        cameraActivator.ActivateCamera(cameraType);
        currentType = cameraType;
    }

}
