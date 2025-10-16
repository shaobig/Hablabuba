using UnityEngine;

public class WeaponTurner : MonoBehaviour, Turner
{
    [SerializeField]
    private float speed = 60f;
    private Transform holdPoint;
    private float scrollInput;

    public void Init(Transform holdPoint)
    {
        this.holdPoint = holdPoint;
    }

    public void Turn()
    {
        float angle = scrollInput * speed * Time.fixedDeltaTime;
        holdPoint.localRotation *= Quaternion.Euler(angle, 0f, 0f);
    }

    public float ScrollInput
    {
        set => scrollInput = value;
    }

}
