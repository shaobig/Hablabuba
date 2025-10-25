using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Game/Ammo/Ammo")]
public class Ammo : ScriptableObject
{
    [SerializeField]
    private AmmoType type = AmmoType.RIFLE;
    [SerializeField]
    private int damage = 20;

    public AmmoType Type => type;
    public int Damage => damage;
}
