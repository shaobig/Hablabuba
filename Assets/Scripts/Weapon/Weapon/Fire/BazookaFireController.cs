using UnityEngine;

public class BazookaFireController : MonoBehaviour, FireController,
    OnTimerFinishedListener
{
    [SerializeField]
    private BazookaTimer bazookaTimer;
    [SerializeField]
    private AmmoEmitter ammoEmitter;
    [SerializeField]
    private Transform emitPoint;
    [SerializeField]
    private BulletPrefab bulletPrefab;
    private Weapon weapon;
    private bool isCharging;

    public void Init(WeaponItem weaponItem, OnAmmoShotListener onAmmoShotListener, OnBulletCollideListener onBulletCollideListener, OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener)
    {
        weapon = weaponItem.Weapon;

        bazookaTimer.Init(this);
        ammoEmitter.Init(emitPoint, bulletPrefab, weaponItem.Weapon.Speed, onAmmoShotListener, onBulletCollideListener, onSetOnShotPlayerCameraListener);
    }

    void Update()
    {
        if (isCharging)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                bazookaTimer.Activate();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                bazookaTimer.Deactivate();
            }
        }
    }

    public void Fire()
    {
        isCharging = true;
    }

    public void OnTimerFinished(float elapsedTime)
    {
        ammoEmitter.Speed = Mathf.RoundToInt(elapsedTime / bazookaTimer.MaxTime * weapon.Speed);
        ammoEmitter.Emit();

        isCharging = false;
        bazookaTimer.Reset();
    }

}
