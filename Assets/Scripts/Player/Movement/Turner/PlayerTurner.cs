using UnityEngine;

public class PlayerTurner : MonoBehaviour, Activator, Deactivator, Turner
{
    [SerializeField]
    private float angleSpeed = 90f;
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

    public void Turn()
    {
        if (Mathf.Abs(input) > delay)
        {
            isMoving = true;

            Quaternion rotationOffset = Quaternion.Euler(0, input * angleSpeed * Time.fixedDeltaTime, 0);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * rotationOffset);
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
