using UnityEngine;

public class VectorRifleForceCalculator : Calculator<Vector3>
{
    private Vector3 hitObject;
    private Vector3 hitPoint;

    public VectorRifleForceCalculator(Vector3 hitObject, Vector3 hitPoint)
    {
        this.hitObject = hitObject;
        this.hitPoint = hitPoint;
    }

    public Vector3 Calculate()
    {
        return hitObject - hitPoint;
    }
    
}
