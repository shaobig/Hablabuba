using UnityEngine;

public class AmmoEmitter : MonoBehaviour, Emitter
{
    [SerializeField]
    private InitAmmoControllerCreator initAmmoControllerCreator;
    private Transform emitPoint;
    private AmmoPrefab ammoPrefab;
    private OnAmmoShotListener onAmmoShotListener;
    private float velocity;

    public void Init(
        Transform emitPoint,
        AmmoPrefab ammoPrefab,
        OnAmmoShotListener onAmmoShotListener,
        OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener
        )
    {
        this.emitPoint = emitPoint;
        this.ammoPrefab = ammoPrefab;
        this.onAmmoShotListener = onAmmoShotListener;

        initAmmoControllerCreator.Init(onAmmoCollideWithTerrainListener);
    }

    public void Emit()
    {
        var ammo = initAmmoControllerCreator.Create(ammoPrefab.Prefab, emitPoint);
        onAmmoShotListener.OnAmmoShot(ammo.transform);

        var rigidbody = ammo.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = emitPoint.forward * velocity;
    }

    public int Velocity
    {
        set => velocity = value;
    }
    
}
