using UnityEngine;

public class WindowControllerGameObjectConverter : MonoBehaviour, GameObjectConverter<WindowController>
{
    public WindowController Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<WindowController>();
    }
}
