using System.Collections.Generic;
using UnityEngine;

public class InitGrenadeShooterGameObjectFactory : MonoBehaviour, GameObjectFactory<GrenadeShootController>
{
    [SerializeField]
    private GrenadeShooterGameObjectFactory grenadeShooterGameObjectFactory;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener;
    private OnNextStepPreparedListener onAmmoCollideListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener,
        OnNextStepPreparedListener onAmmoCollideListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public GrenadeShootController Create(GameObject prefab, Transform target)
    {
        var grenadeShooter = grenadeShooterGameObjectFactory.Create(prefab, target);
        var collisionHandler = new ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory<PlayerController>(onSetCameraOnObjectListener, onAmmoCollideListener).Create();

        grenadeShooter.Init(collisionHandler, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener);
        
        return grenadeShooter;
    }
    
}
