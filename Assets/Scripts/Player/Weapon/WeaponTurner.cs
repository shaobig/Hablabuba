using UnityEngine;

public class WeaponTurner : MonoBehaviour, Turner
{
    [SerializeField]
    private float angleSpeed = 60f;
    private Transform holdPoint;
    private float scrollDownDelta;

    public void Init(Transform holdPoint)
    {
        this.holdPoint = holdPoint;
    }

    public void Turn()
    {
        holdPoint.localRotation *= Quaternion.Euler(scrollDownDelta * angleSpeed, 0f, 0f);
    }

    public float ScrollDownDelta
    {
        get => scrollDownDelta;
        set => scrollDownDelta = value;
    }

}
