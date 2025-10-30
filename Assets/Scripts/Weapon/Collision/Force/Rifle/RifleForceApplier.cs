using UnityEngine;

public class RifleForceApplier : ForceApplier
{
    private const float VERTIFCAL_AMPLIFIER = 0.1f;

    private Calculator<Vector3> calculator;

    public RifleForceApplier(Calculator<Vector3> calculator)
    {
        this.calculator = calculator;
    }

    public void ApplyForce(Rigidbody rigidbody)
    {
        Vector3 forceVector = calculator.Calculate();
        rigidbody.AddForce(Vector3.Scale(forceVector, new(1f, VERTIFCAL_AMPLIFIER, 1f)), ForceMode.Impulse);
    }

}
