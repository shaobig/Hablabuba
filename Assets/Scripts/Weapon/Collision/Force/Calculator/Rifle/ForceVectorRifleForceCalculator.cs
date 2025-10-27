using UnityEngine;

public class ForceVectorRifleForceCalculator : Calculator<Vector3>
{
    private Calculator<Vector3> vectorCalculator;
    private Calculator<float> forceCalculator;

    public ForceVectorRifleForceCalculator(Calculator<Vector3> vectorCalculator, Calculator<float> forceCalculator)
    {
        this.vectorCalculator = vectorCalculator;
        this.forceCalculator = forceCalculator;
    }

    public Vector3 Calculate()
    {
        return vectorCalculator.Calculate() * forceCalculator.Calculate();
    }

}
