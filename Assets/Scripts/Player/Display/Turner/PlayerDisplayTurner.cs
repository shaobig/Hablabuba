using UnityEngine;

public class PlayerDisplayTurner : MonoBehaviour, DisplayTurner
{
    private Transform display;
    private Quaternion currentPlayerRotation;

    public void TurnDisplay()
    {
        display.rotation = currentPlayerRotation;
    }

    public Transform Display
    {
        get => display;
        set => display = value;
    }

    public Quaternion CurrentPlayerRotation
    {
        get => currentPlayerRotation;
        set => currentPlayerRotation = value;
    }
}
