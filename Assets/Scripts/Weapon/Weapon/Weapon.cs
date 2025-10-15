using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private WeaponType weaponType;
    [SerializeField]
    private new string name = "Weapon";
    [SerializeField]
    private int speed = 40;

    public WeaponType WeaponType => weaponType;
    public string Name => name;
    public int Speed => speed;    
}
