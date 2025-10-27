using UnityEngine;

public class RifleCollisionContextImpl : RifleCollisionContext
{
    private GameObject hitObject;
    private Vector3 hitPoint;
    private int damage;

    public RifleCollisionContextImpl(GameObject hitObject, Vector3 hitPoint, int damage)
    {
        this.hitObject = hitObject;
        this.hitPoint = hitPoint;
        this.damage = damage;
    }

    public GameObject HitObject => hitObject;

    public Vector3 HitPoint => hitPoint;

    public int Damage => damage;

}
