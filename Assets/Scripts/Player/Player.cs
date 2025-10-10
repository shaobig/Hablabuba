using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Game/Player/Player")]
public class Player : ScriptableObject
{
    [SerializeField]
    private new string name = "Player";
    [SerializeField]
    private int health = 50;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

}
