using UnityEngine;

public class WeaponProgressBarControllerCreator : MonoBehaviour, Creator<WeaponProgressBarController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;

    public WeaponProgressBarController Create(GameObject prefab, Transform canvas)
    {
        return parentObjectCreator.Create(prefab, canvas).GetComponent<WeaponProgressBarController>();
    }

}
