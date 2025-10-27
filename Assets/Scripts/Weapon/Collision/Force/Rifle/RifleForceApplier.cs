using UnityEngine;

public class RifleForceApplier : ForceApplier
{
    private Calculator<Vector3> calculator;

    public RifleForceApplier(Calculator<Vector3> calculator)
    {
        this.calculator = calculator;
    }

    public void ApplyForce(Rigidbody rigidbody)
    {
        Vector3 forceVector = calculator.Calculate();
        Vector3 flattenedVector = new(forceVector.x, 0.1f * forceVector.y, forceVector.z);
        Debug.Log(flattenedVector);
        rigidbody.AddForce(flattenedVector, ForceMode.Impulse);
    }

}
