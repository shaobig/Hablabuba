using UnityEngine;

public class RifleCollisionContextImpl : RifleCollisionContext
{
    private GameObject hitObject;
    private int damage;

    public RifleCollisionContextImpl(GameObject hitObject, int damage)
    {
        this.hitObject = hitObject;
        this.damage = damage;
    }

    public GameObject HitObject => hitObject;

    public int Damage => damage;

}
