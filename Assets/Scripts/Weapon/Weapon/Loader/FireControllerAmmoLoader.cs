using UnityEngine;

public class FireControllerAmmoLoader : MonoBehaviour, AmmoLoader
{
    [SerializeField]
    private AmmoPrefab ammoPrefab;

    public AmmoPrefab LoadAmmo()
    {
        return ammoPrefab;
    }
    
}
