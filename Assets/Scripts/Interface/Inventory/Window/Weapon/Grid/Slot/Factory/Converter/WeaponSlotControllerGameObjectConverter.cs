using UnityEngine;

public class WeaponSlotControllerGameObjectConverter : MonoBehaviour, GameObjectConverter<WeaponSlotController>
{
    public WeaponSlotController Convert(GameObject gameObject)
    {
        return gameObject.GetComponent<WeaponSlotController>();
    }
}
