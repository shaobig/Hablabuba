using UnityEngine;

public class PlayerTurner : MonoBehaviour, Activator, Deactivator, Turner
{
    [SerializeField]
    private float angleSpeed = 60f;
    [SerializeField]
    private float deadZone = 0.1f;
    private new Rigidbody rigidbody;
    private float moveInput;
    private float delay;

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

    public void Turn()
    {
        if (Mathf.Abs(moveInput) > delay)
        {
            Quaternion rotationOffset = Quaternion.Euler(0, moveInput * angleSpeed * Time.fixedDeltaTime, 0);
            rigidbody.MoveRotation(rigidbody.rotation * rotationOffset);
        }
    }

    public float MoveInput
    {
        get => moveInput;
        set => moveInput = value;
    }

}
