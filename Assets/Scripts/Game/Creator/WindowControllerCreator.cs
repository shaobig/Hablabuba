using UnityEngine;

public class WindowControllerCreator : MonoBehaviour, Creator<WindowController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;

    public WindowController Create(GameObject gameObject, Transform canvasTransform)
    {
        return parentObjectCreator.Create(gameObject, canvasTransform).GetComponent<WindowController>();
    }

}
