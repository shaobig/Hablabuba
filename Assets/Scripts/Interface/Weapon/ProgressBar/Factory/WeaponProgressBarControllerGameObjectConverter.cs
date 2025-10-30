using UnityEngine;

public class WeaponProgressBarControllerGameObjectConverter : MonoBehaviour, GameObjectConverter<WeaponProgressBarController>
{
    public WeaponProgressBarController Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<WeaponProgressBarController>();
    }
}
