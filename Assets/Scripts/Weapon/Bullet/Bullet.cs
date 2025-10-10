using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Game/Bullet/Bullet")]
public class Bullet : ScriptableObject
{
    [SerializeField]
    private BulletType type = BulletType.RIFFLE;
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    private int radius = 0;

    public BulletType Type => type;
    public int Damage => damage;
    public int Radius => radius;
}
