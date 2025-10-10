using TMPro;
using UnityEngine;

public class DisplayController : MonoBehaviour, DisplayTurner, DisplaySizeMaker, Painter
{
    private const int DISABLED_TEXT_ALPHA = 0;
    private const int ENABLED_TEXT_ALPHA = 255;

    [SerializeField]
    private PlayerDisplayTurner displayTurner;
    [SerializeField]
    private PlayerDisplaySizeMaker displaySizeMaker;
    [SerializeField]
    private DisplayPainter displayPainter;
    [SerializeField]
    private Transform display;
    [SerializeField]
    private TextMeshPro healthText;
    [SerializeField]
    private TextMeshPro nameText;
    private Transform currentPlayer;
    private Color colour;

    public void Init(Player player, Color colour)
    {
        nameText.SetText(player.Name);
        healthText.SetText(player.Health.ToString());

        displayTurner.Display = display;
        displaySizeMaker.Display = display;

        displayPainter.NameText = nameText;
        displayPainter.HealthText = healthText;

        displayPainter.Colour = colour;
    }

    public void SetHealthText(int health)
    {
        healthText.SetText(health.ToString());
    }

    public void DisableText()
    {
        healthText.alpha = DISABLED_TEXT_ALPHA;
        nameText.alpha = DISABLED_TEXT_ALPHA;
    }

    public void EnableText()
    {
        healthText.alpha = ENABLED_TEXT_ALPHA;
        nameText.alpha = ENABLED_TEXT_ALPHA;
    }

    public void Paint()
    {
        displayPainter.Paint();
    }

    public void MakeDisplaySize()
    {
        displaySizeMaker.MakeDisplaySize();
    }

    public void TurnDisplay()
    {
        displayTurner.TurnDisplay();
    }

    public Transform CurrentPlayer
    {
        get => currentPlayer;
        set
        {
            currentPlayer = value;
            displayTurner.CurrentPlayerRotation = currentPlayer.rotation;
            displaySizeMaker.CurrentPlayer = currentPlayer;
        }
    }

    public Color Colour
    {
        get => colour;
        set
        {
            colour = value;
            displayPainter.Colour = value;
        }
    }

}
