using UnityEngine;

public class WindowControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WindowController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WindowControllerGameObjectConverter gameObjectConverter;

    public WindowController Create(GameObject gameObject, Transform canvasTransform)
    {
        return gameObjectConverter.Convert(parentGameObjectFactory.Create(gameObject, canvasTransform));
    }

}
