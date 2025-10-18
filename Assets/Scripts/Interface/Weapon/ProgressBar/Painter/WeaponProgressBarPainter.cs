using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponProgressBarPainter : MonoBehaviour, Painter
{
    [SerializeField]
    private List<Color> colorList = new() { Color.green, Color.yellow, Color.red };
    private Image handleImage;
    private float sliderValue;

    public void Init(Image handleImage)
    {
        this.handleImage = handleImage;
    }

    public void Paint()
    {
        float colourValue = sliderValue * (colorList.Count - 1);

        int currentIndex = Mathf.FloorToInt(colourValue);
        int clampedIndex = Math.Clamp(currentIndex, 0, colorList.Count - 2);

        float t = colourValue - currentIndex;

        Color newColour = Color.Lerp(colorList[clampedIndex], colorList[clampedIndex + 1], t);
        handleImage.color = newColour;
    }

    public float SliderValue
    {
        set => sliderValue = value;
    }

}
