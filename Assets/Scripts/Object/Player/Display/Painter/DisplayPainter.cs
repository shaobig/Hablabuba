using TMPro;
using UnityEngine;

public class DisplayPainter : MonoBehaviour, Painter
{
    private TextMeshPro nameText;
    private TextMeshPro healthText;
    private Color colour;

    public void Init(TextMeshPro nameText, TextMeshPro healthText, Color colour)
    {
        this.nameText = nameText;
        this.healthText = healthText;
        this.colour = colour;
    }

    public void Paint()
    {
        nameText.color = colour;
        healthText.color = colour;
    }

    public TextMeshPro NameText
    {
        get => nameText;
        set => nameText = value;
    }

    public TextMeshPro HealthText
    {
        get => healthText;
        set => healthText = value;
    }

    public Color Colour
    {
        get => colour;
        set => colour = value;
    }

}
