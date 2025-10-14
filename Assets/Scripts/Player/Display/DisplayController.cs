using TMPro;
using UnityEngine;

public class DisplayController : MonoBehaviour, Painter, DisplayRefresher
{
    private const int DISABLED_TEXT_ALPHA = 0;
    private const int ENABLED_TEXT_ALPHA = 255;

    [SerializeField]
    private DisplayTurner displayTurner;
    [SerializeField]
    private DisplaySizeSetter displaySizeSetter;
    [SerializeField]
    private DisplayPainter displayPainter;
    [SerializeField]
    private Transform display;
    [SerializeField]
    private TextMeshPro healthText;
    [SerializeField]
    private TextMeshPro nameText;

    public void Init(Player player, Color colour)
    {
        nameText.SetText(player.Name);
        healthText.SetText(player.Health.ToString());

        displayTurner.Init(display);
        displaySizeSetter.Init(display);
        displayPainter.Init(nameText, healthText, colour);
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

    public void RefreshDisplay()
    {
        displayTurner.Turn();
        displaySizeSetter.SetSize();
    }

    public Transform Camera
    {
        set
        {
            displayTurner.Camera = value;
            displaySizeSetter.Camera = value;
        }
    }

    public Color Colour
    {
        set => displayPainter.Colour = value;
    }

}
