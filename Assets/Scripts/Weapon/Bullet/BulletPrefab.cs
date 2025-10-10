using UnityEngine;

[CreateAssetMenu(fileName = "BulletPrefab", menuName = "Game/Bullet/Bullet Prefab")]
public class BulletPrefab : ScriptableObject
{
    [SerializeField]
    private new string name = "Bullet";
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private GameObject prefab;

    public string Name => name;
    public Bullet Bullet => bullet;
    public GameObject Prefab => prefab;
}
