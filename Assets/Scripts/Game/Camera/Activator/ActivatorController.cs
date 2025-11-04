using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour, CameraActivator,
    OnNextStepPreparedListener
{
    private HashSet<CameraType> cameraTypeSet;
    private CameraActivator cameraActivator;
    private bool isBlocked;

    public void Init(CameraActivator cameraActivator)
    {
        this.cameraActivator = cameraActivator;
        cameraTypeSet = new HashSet<CameraType>(new CameraType[]{CameraType.PLAYER});
    }

    public void ActivateCamera(CameraType cameraType)
    {
        if (isBlocked && cameraTypeSet.Contains(cameraType))
        {
            return;
        }
        if (CameraType.AMMO.Equals(cameraType))
        {
            isBlocked = true;
        }

        cameraActivator.ActivateCamera(cameraType);
    }

    public void OnNextStepPrepared()
    {
        isBlocked = false;
    }

}
