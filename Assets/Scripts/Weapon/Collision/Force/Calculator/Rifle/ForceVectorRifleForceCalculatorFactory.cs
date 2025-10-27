using UnityEngine;

public class ForceVectorRifleForceCalculatorFactory : Factory<Calculator<Vector3>>
{
    private Factory<Calculator<Vector3>> vectorCalculatorFactory;
    private Factory<Calculator<float>> forceCalculatorFactory;

    public ForceVectorRifleForceCalculatorFactory(Factory<Calculator<Vector3>> vectorCalculatorFactory, Factory<Calculator<float>> forceCalculatorFactory)
    {
        this.vectorCalculatorFactory = vectorCalculatorFactory;
        this.forceCalculatorFactory = forceCalculatorFactory;
    }

    public Calculator<Vector3> Get()
    {
        return new ForceVectorRifleForceCalculator(vectorCalculatorFactory.Get(), forceCalculatorFactory.Get());
    }

}
