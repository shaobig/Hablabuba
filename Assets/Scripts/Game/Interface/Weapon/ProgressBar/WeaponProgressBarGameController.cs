using UnityEngine;

public class WeaponProgressBarGameController : MonoBehaviour, Activator, Deactivator,
    OnWeaponProgressBarChangeValueListener
{
    [SerializeField]
    private WeaponProgressBarControllerCreator weaponProgressBarControllerCreator;
    [SerializeField]
    private GameObjectRemover gameObjectRemover;
    [SerializeField]
    private GameObject progressBarPrefab;
    private WeaponProgressBarController weaponProgressBarController;
    private Transform canvas;

    public void Activate()
    {
        weaponProgressBarController = weaponProgressBarControllerCreator.Create(progressBarPrefab, canvas);
        weaponProgressBarController.Init();
    }

    public void Deactivate()
    {
        gameObjectRemover.Remove(weaponProgressBarController.gameObject);
    }

    public void Init(Transform canvas)
    {
        this.canvas = canvas;
    }

    public void OnWeaponProgressBarChangeValue(float value)
    {
        weaponProgressBarController.OnWeaponProgressBarChangeValue(value);
    }

}
