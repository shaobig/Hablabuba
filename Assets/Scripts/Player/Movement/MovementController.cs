using UnityEngine;

public class MovementController : MonoBehaviour, Activator, Deactivator,
    OnMoveKeyPressedListener
{
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private PlayerInputTurner playerTurner;
    private Vector2 moveInput;

    public void Init(Rigidbody rigidbody)
    {
        rigidbody.freezeRotation = true;

        playerMover.Init(rigidbody);
        playerTurner.Init(rigidbody);
    }

    void FixedUpdate()
    {
        if (playerMover.enabled)
        {
            playerMover.Move(moveInput.y);
        }
        if (playerTurner.enabled)
        {
            playerTurner.Turn(moveInput.x);
        }
    }

    public void Activate()
    {
        enabled = true;

        playerMover.Activate();
        playerTurner.Activate();
    }

    public void Deactivate()
    {
        enabled = false;

        playerMover.Deactivate();
        playerTurner.Deactivate();
    }

    public void OnMoveKeyPressed(Vector2 moveInput)
    {
        this.moveInput = moveInput;
    }

}
