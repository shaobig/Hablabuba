using UnityEngine;

public class AmmoControllerCreator : MonoBehaviour, Creator<AmmoController>
{
    [SerializeField]
    private SceneObjectCreator sceneObjectCreator;

    public AmmoController Create(GameObject prefab, Transform target)
    {
        return sceneObjectCreator.Create(prefab, target).GetComponent<AmmoController>();
    }
    
}
