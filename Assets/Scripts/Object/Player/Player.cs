using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Game/Player/Player")]
public class Player : ScriptableObject
{
    [SerializeField]
    private new string name = "Player";

    public string Name
    {
        get => name;
        set => name = value;
    }

}
