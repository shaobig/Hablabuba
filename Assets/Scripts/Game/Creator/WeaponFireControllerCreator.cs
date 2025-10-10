using UnityEngine;

public class WeaponFireControllerCreator : MonoBehaviour, Creator<WeaponFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;

    public WeaponFireController Create(GameObject gameObject, Transform target)
    {
        return parentObjectCreator.Create(gameObject, target).GetComponent<WeaponFireController>();
    }

}
