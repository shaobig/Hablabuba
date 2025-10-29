using UnityEngine;

public class RifleForceApplierFactory : Factory<ForceApplier>
{
    private Factory<Calculator<Vector3>> calculatorFactory;

    public RifleForceApplierFactory(Factory<Calculator<Vector3>> calculatorFactory)
    {
        this.calculatorFactory = calculatorFactory;
    }

    public ForceApplier Create()
    {
        return new RifleForceApplier(calculatorFactory.Create());
    }

}
