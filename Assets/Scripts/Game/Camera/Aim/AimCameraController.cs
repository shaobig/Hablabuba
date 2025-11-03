using Unity.Cinemachine;
using UnityEngine;

public class AimCameraController : MonoBehaviour, OnAimTakenListener
{
    private new CinemachineCamera camera;

    public void Init(CinemachineCamera camera)
    {
        this.camera = camera;
    }

    public void OnAimTaken(Transform aimPoint)
    {
        camera.Follow = aimPoint;
    }
    
}
