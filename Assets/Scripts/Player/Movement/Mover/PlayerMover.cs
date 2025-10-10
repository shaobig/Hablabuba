using UnityEngine;

public class PlayerMover : MonoBehaviour, Activator, Deactivator, Mover
{
    [SerializeField]
    private float speed = 5f;
    private Rigidbody playerRigidbody;
    private float input;
    private float delay;
    private bool isMoving;

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
        if (Mathf.Abs(input) > delay)
        {
            isMoving = true;

            Vector3 moveDirection = transform.forward * input;
            playerRigidbody.MovePosition(playerRigidbody.position + speed * Time.fixedDeltaTime * moveDirection);
        }
        else
        {
            isMoving = false;
        }
    }

    public Rigidbody PlayerRigidbody
    {
        get => playerRigidbody;
        set => playerRigidbody = value;
    }

    public float Input
    {
        get => input;
        set => input = value;
    }

    public float Delay
    {
        get => delay;
        set => delay = value;
    }

    public bool IsMoving => isMoving;

}
