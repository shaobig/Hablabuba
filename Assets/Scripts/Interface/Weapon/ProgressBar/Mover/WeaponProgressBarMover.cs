using UnityEngine;
using UnityEngine.UI;

public class WeaponProgressBarMover : MonoBehaviour, Mover
{
    private Slider slider;
    private float sliderValue;

    public void Init(Slider slider)
    {
        this.slider = slider;
    }

    public void Move()
    {
        slider.value = sliderValue;
    }

    public float SliderValue
    {
        set => sliderValue = value;
    }

}
