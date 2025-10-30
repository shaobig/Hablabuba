using UnityEngine;
using UnityEngine.UI;

public class WeaponProgressBarMover : MonoBehaviour, Mover
{
    private Slider slider;

    public void Init(Slider slider)
    {
        this.slider = slider;
    }

    public void Move(float input)
    {
        slider.value = input;
    }

}
