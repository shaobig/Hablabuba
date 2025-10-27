using UnityEngine;

public class VectorRifleForceCalculatorFactory : Factory<Calculator<Vector3>>
{
    private Vector3 hitObject;
    private Vector3 hitPoint;

    public VectorRifleForceCalculatorFactory(Vector3 hitObject, Vector3 hitPoint)
    {
        this.hitObject = hitObject;
        this.hitPoint = hitPoint;
    }

    public Calculator<Vector3> Get()
    {
        return new VectorRifleForceCalculator(hitObject, hitPoint);
    }

}
