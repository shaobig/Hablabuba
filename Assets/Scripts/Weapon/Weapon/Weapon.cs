using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private new string name = "Weapon";
    [SerializeField]
    private int speed = 40;

    public string Name => name;
    public int Speed => speed;    
}
