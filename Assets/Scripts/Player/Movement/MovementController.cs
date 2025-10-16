using UnityEngine;

public class MovementController : MonoBehaviour, Activator, Deactivator,
    OnPlayerMoveListener
{
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private PlayerTurner playerTurner;
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
            playerMover.MoveInput = moveInput.y;
            playerMover.Move();
        }
        if (playerTurner.enabled)
        {
            playerTurner.MoveInput = moveInput.x;
            playerTurner.Turn();
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

    public void OnPlayerMove(Vector2 moveInput)
    {
        this.moveInput = moveInput;
    }

}
