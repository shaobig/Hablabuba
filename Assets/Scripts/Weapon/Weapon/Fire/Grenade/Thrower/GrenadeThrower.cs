using UnityEngine;

public class GrenadeThrower : MonoBehaviour, Thrower,
    OnTimerCountListener, OnTimerFinishListener
{
    [SerializeField]
    private WeaponTimer weaponTimer;
    private new Rigidbody rigidbody;
    private OnGrenadeDestroyListener onGrenadeDestroyListener;
    private float force;

    public void Init(
        Rigidbody rigidbody,
        OnGrenadeDestroyListener onGrenadeDestroyListener)
    {
        this.rigidbody = rigidbody;
        this.rigidbody.isKinematic = true;

        this.onGrenadeDestroyListener = onGrenadeDestroyListener;

        weaponTimer.Init(this, this);
    }

    public void Throw()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force * transform.forward, ForceMode.Impulse);

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
