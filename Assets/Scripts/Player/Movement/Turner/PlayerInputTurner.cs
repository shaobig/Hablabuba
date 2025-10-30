using UnityEngine;

public class PlayerInputTurner : MonoBehaviour, Activator, Deactivator, InputTurner
{
    [SerializeField]
    private float angleSpeed = 60f;
    [SerializeField]
    private float deadZone = 0.1f;
    private new Rigidbody rigidbody;

    public void Init(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

    public void Turn(float input)
    {
        if (Mathf.Abs(input) > deadZone)
        {
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(angleSpeed * input * Time.fixedDeltaTime * Vector3.up));
        }
    }

}
