using System;
using UnityEngine;

public class HealthController : MonoBehaviour, OnBulletCollideOnPlayerListener
{
    private const int DEAD_PLAYER_HEALTH = 0;

    private int health;

    public void Init(int health)
    {
        this.health = health;
    }

    public void OnBulletCollideOnPlayer(HitBullet bullet)
    {
        health = Math.Max(DEAD_PLAYER_HEALTH, health - bullet.Damage);
    }

    public int Health => health;

    public bool IsDead => health == DEAD_PLAYER_HEALTH;
    
}
