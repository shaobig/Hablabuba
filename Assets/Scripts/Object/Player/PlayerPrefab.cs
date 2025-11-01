using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPrefab", menuName = "Game/Player/Player Prefab")]
public class PlayerPrefab : ScriptableObject
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject prefab;

    public Player Player
    {
        get => player;
        set => player = value;
    }

    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }

}
