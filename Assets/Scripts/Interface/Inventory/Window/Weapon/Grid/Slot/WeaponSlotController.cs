using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotController : MonoBehaviour
{
    [SerializeField]
    private Image background;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMP_Text amountText;

    public void Init(Sprite sprite, string amountText)
    {
        image.sprite = sprite;
        this.amountText.SetText(amountText);
    }

    public void SetBackgroundColour(Color colour)
    {
        background.color = colour;
    }

}
