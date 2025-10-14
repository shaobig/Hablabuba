using UnityEngine;

public class DisplayTurner : MonoBehaviour, Turner
{
    private Transform display;
    private new Transform camera;

    public void Init(Transform display)
    {
        this.display = display;
    }

    public void Turn()
    {
        display.rotation = camera.rotation;
    }

    public Transform Display
    {
        get => display;
        set => display = value;
    }

    public Transform Camera
    {
        get => camera;
        set => camera = value;
    }
    
}
