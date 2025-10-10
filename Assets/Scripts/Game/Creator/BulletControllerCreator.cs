using UnityEngine;

public class BulletControllerCreator : MonoBehaviour, Creator<BulletController>
{
    [SerializeField]
    private SceneObjectCreator sceneObjectCreator;

    public BulletController Create(GameObject prefab, Transform target)
    {
        return sceneObjectCreator.Create(prefab, target).GetComponent<BulletController>();
    }

}
