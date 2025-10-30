using UnityEngine;

public class WeaponInputTurner : MonoBehaviour, InputTurner
{
    [SerializeField]
    private float speed = 60f;
    private Transform holdPoint;

    public void Init(Transform holdPoint)
    {
        this.holdPoint = holdPoint;
    }

    public void Turn(float input)
    {
        float angle = input * speed * Time.fixedDeltaTime;
        holdPoint.localRotation *= Quaternion.Euler(angle, 0f, 0f);
    }

}
