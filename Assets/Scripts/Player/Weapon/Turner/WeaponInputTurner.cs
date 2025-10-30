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
        holdPoint.localRotation *= Quaternion.Euler(Vector3.right * input * speed * Time.fixedDeltaTime);
    }

}
