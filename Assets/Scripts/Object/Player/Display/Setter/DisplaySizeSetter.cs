using UnityEngine;

public class DisplaySizeSetter : MonoBehaviour, SizeSetter
{
    [SerializeField]
    private float baseSize = 1f;
    [SerializeField]
    private float transitionStart = 20f;
    [SerializeField]
    private float transitionOffset = 5f;
    [SerializeField]
    private float curvePower = 0.4f;
    [SerializeField]
    private float growthFactor = 2f;
    private Transform display;
    private new Transform camera;

    public void Init(Transform display)
    {
        this.display = display;
    }

    public void SetSize()
    {
        float distance = Vector3.Distance(transform.position, camera.position);

        float t = Mathf.InverseLerp(transitionStart - transitionOffset, transitionStart + transitionOffset, distance);
        float powerSize = baseSize + growthFactor * Mathf.Pow(distance, curvePower);
        float smoothSIze = Mathf.Lerp(baseSize, powerSize, t);

        display.localScale = Vector3.one * smoothSIze;
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
