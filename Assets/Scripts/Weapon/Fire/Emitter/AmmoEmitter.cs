using UnityEngine;

public class AmmoEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private InitAmmoControllerGameObjectFactory initAmmoControllerGameObjectFactory;
    private Transform emitPoint;
    private AmmoPrefab ammoPrefab;
    private OnAmmoShotListener onAmmoShotListener;
    private float velocity;

    public void Init(
        Transform emitPoint,
        AmmoPrefab ammoPrefab,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideListener onAmmoCollideListener
        )
    {
        this.emitPoint = emitPoint;
        this.ammoPrefab = ammoPrefab;
        this.onAmmoShotListener = onAmmoShotListener;

        initAmmoControllerGameObjectFactory.Init(onAmmoCollideListener);
    }

    public void Emit()
    {
        var ammo = initAmmoControllerGameObjectFactory.Create(ammoPrefab.Prefab, emitPoint);
        onAmmoShotListener.OnAmmoShot(ammo.transform);

        var rigidbody = ammo.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = emitPoint.forward * velocity;
    }

    public int Velocity
    {
        set => velocity = value;
    }
    
}
