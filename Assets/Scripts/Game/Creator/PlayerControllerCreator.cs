using UnityEngine;

public class PlayerControllerCreator : MonoBehaviour, Creator<PlayerController>
{
    [SerializeField]
    private SceneObjectCreator sceneObjectCreator;

    public PlayerController Create(GameObject gameObject, Transform target)
    {
        return sceneObjectCreator.Create(gameObject, target).GetComponent<PlayerController>();
    }

}
