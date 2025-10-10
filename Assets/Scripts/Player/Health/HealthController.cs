using UnityEngine;

public class HealthController : MonoBehaviour, OnBulletCollideOnPlayerListener
{
    private int health;

    public void Init(int health)
    {
        this.health = health;
    }

    public void OnBulletCollideOnPlayer(HitBullet bullet)
    {
        health -= bullet.Damage;
    }

    public int Health => health;

    public bool IsDead => health <= 0;
    
}
