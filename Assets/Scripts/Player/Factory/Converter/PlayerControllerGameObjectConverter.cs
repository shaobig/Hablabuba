using UnityEngine;

public class PlayerControllerGameObjectConverter : MonoBehaviour, GameObjectConverter<PlayerController>
{
    public PlayerController Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<PlayerController>();
    }
}
