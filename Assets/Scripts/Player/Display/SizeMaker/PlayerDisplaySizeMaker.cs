using UnityEngine;

public class PlayerDisplaySizeMaker : MonoBehaviour, DisplaySizeMaker
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
    private Transform currentPlayer;

    public void MakeDisplaySize()
    {
        float distance = Vector3.Distance(transform.position, currentPlayer.position);
        
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

    public Transform CurrentPlayer
    {
        get => currentPlayer;
        set => currentPlayer = value;
    }

}
