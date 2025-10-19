using UnityEngine;

public class GrenadeFireControllerCreator : MonoBehaviour, Creator<GrenadeFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        return parentObjectCreator.Create(prefab, target).GetComponent<GrenadeFireController>();
    }

}
