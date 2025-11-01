using System;
using UnityEngine;

public class HealthController : MonoBehaviour, DamageTaker
{
    private const int DESTROY_HEALTH = 0;

    private int health;

    public void Init(int health)
    {
        this.health = health;
    }

    public void TakeDamage(int damage)
    {
        health = Math.Max(DESTROY_HEALTH, health - damage);
    }

    public int Health => health;

    public bool IsDestroyed => health == DESTROY_HEALTH;
    
}
