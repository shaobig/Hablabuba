using System;
using UnityEngine;

public class MovementController : MonoBehaviour, Activator, Deactivator, Mover, Turner
{
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private PlayerTurner playerTurner;
    [SerializeField]
    [Range(0, 1)]
    private float delay = 0.01f;
    private Rigidbody playerRigidbody;

    public void Init(Rigidbody rigidbody)
    {
        playerMover.PlayerRigidbody = rigidbody;
        playerTurner.PlayerRigidbody = rigidbody;

        playerMover.Delay = delay;
        playerTurner.Delay = delay;
    }

    void FixedUpdate()
    {
        if (playerMover.enabled)
        {
            playerMover.Input = Input.GetAxis("Vertical");
            playerMover.Move();
        }
        if (playerTurner.enabled)
        {
            playerTurner.Input = Input.GetAxis("Horizontal");
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

    public void Move()
    {
        if (playerMover.enabled)
        {
            playerMover.Input = Input.GetAxis("Vertical");
            playerMover.Move();
        }
    }

    public void Turn()
    {
        if (playerTurner.enabled)
        {
            playerTurner.Input = Input.GetAxis("Horizontal");
            playerTurner.Turn();
        }
    }

    public Rigidbody PlayerRigidbody
    {
        get => playerRigidbody;
        set => playerRigidbody = value;
    }

    public bool IsMoving
    {
        get => playerMover.IsMoving || playerTurner.IsMoving;
    }

}
