using UnityEngine;
using UnityEngine.UI;

public class WeaponProgressBarController : MonoBehaviour, Activator, Deactivator,
    OnWeaponProgressBarChangeValueListener
{
    [SerializeField]
    private WeaponProgressBarMover weaponProgressBarMover;
    [SerializeField]
    private WeaponProgressBarPainter weaponProgressBarPainter;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image handleImage;

    public void Init()
    {
        weaponProgressBarMover.Init(slider);
        weaponProgressBarPainter.Init(handleImage);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void OnWeaponProgressBarChangeValue(float value)
    {
        weaponProgressBarMover.SliderValue = value;
        weaponProgressBarPainter.SliderValue = value;
        
        weaponProgressBarMover.Move();
        weaponProgressBarPainter.Paint();
    }

}
