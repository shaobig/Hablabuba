using UnityEngine;

public class PlayerMover : MonoBehaviour, Activator, Deactivator
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float deadZone = 0.1f;
    private new Rigidbody rigidbody;
    private float moveInput;

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

    public void Move()
    {
        if (Mathf.Abs(moveInput) > deadZone)
        {
            Vector3 moveVelocity = moveInput * speed * transform.forward;
            Vector3 smoothVelocity = Vector3.Lerp(rigidbody.linearVelocity, moveVelocity, acceleration * Time.fixedDeltaTime);
            smoothVelocity.y = rigidbody.linearVelocity.y;
            rigidbody.linearVelocity = smoothVelocity;
        }
        else
        {
            Vector3 smoothVelocity = Vector3.Lerp(rigidbody.linearVelocity, Vector3.zero, acceleration * Time.fixedDeltaTime);
            smoothVelocity.y = rigidbody.linearVelocity.y;
            rigidbody.linearVelocity = smoothVelocity;
        }
    }

    public float MoveInput
    {
        get => moveInput;
        set => moveInput = value;
    }

}
