using UnityEngine;

public class AmmoControllerGameObjectConverter : MonoBehaviour, GameObjectConverter<AmmoController>
{
    public AmmoController Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<AmmoController>();
    }
}
