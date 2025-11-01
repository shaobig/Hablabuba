using UnityEngine;

public class HealthTaker : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    public int Health => health;
}
