using UnityEngine;

public class WindowControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<WindowController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    [SerializeField]
    private WindowControllerGameObjectConverter GameObjectConverter;

    public WindowController Create(GameObject gameObject, Transform canvasTransform)
    {
        return GameObjectConverter.Convert(parentGameObjectFactory.Create(gameObject, canvasTransform));
    }

}
