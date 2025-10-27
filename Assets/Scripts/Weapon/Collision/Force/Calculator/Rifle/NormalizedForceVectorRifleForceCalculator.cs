using UnityEngine;

public class NormalizedForceVectorRifleForceCalculator : Calculator<Vector3>
{
    private const float VERTICAL_AMPLIFIER = 0.1f;

    private Calculator<Vector3> vectorCalculator;

    public NormalizedForceVectorRifleForceCalculator(Calculator<Vector3> vectorCalculator)
    {
        this.vectorCalculator = vectorCalculator;
    }

    public Vector3 Calculate()
    {
        return Vector3.Scale(vectorCalculator.Calculate(), new Vector3(1f, VERTICAL_AMPLIFIER, 1f));
    }

}
