using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPrefab", menuName = "Game/Weapon/Weapon Prefab")]
public class WeaponPrefab : ScriptableObject
{
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private GameObject prefab;

    public Weapon Weapon => weapon;
    public Sprite Sprite => sprite;
    public GameObject Prefab => prefab;
    
}
