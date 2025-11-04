using System.Collections.Generic;

public class BlockCameraActivatorFactory : CameraActivatorFactory
{
    private Dictionary<CameraType, CameraType> blockingDictionary;
    private CameraActivator cameraActivator;
    private CameraType currentType;

    public BlockCameraActivatorFactory(Dictionary<CameraType, CameraType> blockingDictionary, CameraActivator cameraActivator, CameraType currentType)
    {
        this.blockingDictionary = blockingDictionary;
        this.cameraActivator = cameraActivator;
        this.currentType = currentType;
    }

    public CameraActivator Create()
    {
        return new BlockCameraActivator(blockingDictionary, cameraActivator, currentType);
    }
    
}
