using UnityEngine;

public class GrenadeThrower : MonoBehaviour, Thrower,
    OnTimerCountListener, OnTimerFinishListener
{
    [SerializeField]
    private WeaponTimer weaponTimer;
    private Rigidbody rb;
    private OnGrenadeDestroyListener onGrenadeDestroyListener;
    private float force;

    public void Init(
        Rigidbody rb,
        OnGrenadeDestroyListener onGrenadeDestroyListener)
    {
        this.rb = rb;
        this.rb.isKinematic = true;

        this.onGrenadeDestroyListener = onGrenadeDestroyListener;

        weaponTimer.Init(this, this);
    }

    public void Throw()
    {
        rb.isKinematic = false;
        rb.AddForce(force * transform.forward, ForceMode.Impulse);

        weaponTimer.Activate();
    }

    public void OnTimerCount(float elapsedTime)
    {
        
    }

    public void OnTimerFinish(float elapsedTime)
    {
        onGrenadeDestroyListener.OnGrenadeDestroy();
    }

    public float Force
    {
        set => force = value;
    }

}
