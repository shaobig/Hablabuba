using UnityEngine;
using UnityEngine.UI;

public class WeaponProgressBarController : MonoBehaviour, Activator, Deactivator,
    OnWeaponProgressBarChangeValueListener
{
    [SerializeField]
    private WeaponProgressBarMover weaponProgressBarMover;
    [SerializeField]
    private Slider slider;

    public void Init()
    {
        weaponProgressBarMover.Init(slider);
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
        weaponProgressBarMover.Move();
    }

}
