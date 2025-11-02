using System;
using UnityEngine;

public class HealthController : MonoBehaviour, DamageTaker
{
    private const int DEATH_HEALTH = 0;

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    public void Init()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Math.Max(DEATH_HEALTH, currentHealth - damage);
    }

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public bool IsDead => currentHealth == DEATH_HEALTH;
    
}
