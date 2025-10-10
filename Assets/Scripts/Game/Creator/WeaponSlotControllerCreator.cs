using UnityEngine;

public class WeaponSlotControllerCreator : MonoBehaviour, Creator<WeaponSlotController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;

    public WeaponSlotController Create(GameObject prefab, Transform transform)
    {
        return parentObjectCreator.Create(prefab, transform).GetComponent<WeaponSlotController>();
    }

}
