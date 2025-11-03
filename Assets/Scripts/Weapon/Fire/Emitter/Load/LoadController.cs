using UnityEngine;

public class LoadController : MonoBehaviour, AmmoLoader
{
    [SerializeField]
    private AmmoPrefab ammoPrefab;

    public AmmoPrefab LoadAmmo()
    {
        return ammoPrefab;
    }
    
}
