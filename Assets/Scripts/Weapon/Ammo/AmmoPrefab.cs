using UnityEngine;

[CreateAssetMenu(fileName = "AmmoPrefab", menuName = "Game/Ammo/Prefab")]
public class AmmoPrefab : ScriptableObject
{
    [SerializeField]
    private new string name = "Ammo";
    [SerializeField]
    private Ammo ammo;
    [SerializeField]
    private GameObject prefab;

    public string Name => name;
    public Ammo Ammo => ammo;
    public GameObject Prefab => prefab;
}
