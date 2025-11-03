using System.Collections.Generic;

public class BlockCameraDictionaryFactory : DictionaryFactory<CameraType, CameraType>
{
    public Dictionary<CameraType, CameraType> Create()
    {
        return new Dictionary<CameraType, CameraType>()
        {
            { CameraType.AMMO, CameraType.AIM },
            { CameraType.SHOT, CameraType.AIM }
        };
    }
}
