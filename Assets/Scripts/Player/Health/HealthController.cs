using System;
using UnityEngine;

public class HealthController : MonoBehaviour, OnDamagePlayerListener
{
    private const int DEAD_PLAYER_HEALTH = 0;

    private int health;

    public void Init(int health)
    {
        this.health = health;
    }

    public void OnDamagePlayer(int damage)
    {
        health = Math.Max(DEAD_PLAYER_HEALTH, health - damage);
    }

    public int Health => health;

    public bool IsDead => health == DEAD_PLAYER_HEALTH;
    
}
