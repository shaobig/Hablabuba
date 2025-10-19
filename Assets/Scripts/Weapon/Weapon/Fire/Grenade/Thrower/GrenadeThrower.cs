using UnityEngine;

public class GrenadeThrower : MonoBehaviour, Thrower
{
    [SerializeField]
    private float force = 5f;
    private Rigidbody rb;

    public void Init(Rigidbody rb)
    {
        this.rb = rb;
        this.rb.isKinematic = true;
    }

    public void Throw()
    {
        rb.isKinematic = false;
        rb.AddForce(force * transform.forward, ForceMode.Impulse);
        Debug.Log(force * transform.forward);
    }

}
