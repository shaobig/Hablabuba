using UnityEngine;

public class NormalizedForceVectorRifleForceCalculatorFactory : Factory<Calculator<Vector3>>
{
    private Factory<Calculator<Vector3>> vectorCalculatorFactory;

    public NormalizedForceVectorRifleForceCalculatorFactory(Factory<Calculator<Vector3>> vectorCalculatorFactory)
    {
        this.vectorCalculatorFactory = vectorCalculatorFactory;
    }

    public Calculator<Vector3> Create()
    {
        return new NormalizedForceVectorRifleForceCalculator(vectorCalculatorFactory.Create());
    }

}
