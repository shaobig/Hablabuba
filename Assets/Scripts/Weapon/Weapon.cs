using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private WeaponType type;
    [SerializeField]
    private new string name = "Weapon";

    public WeaponType Type => type;
    public string Name => name;
    
}
