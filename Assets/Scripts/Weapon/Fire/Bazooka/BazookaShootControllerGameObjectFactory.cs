using System.Collections.Generic;
using UnityEngine;

public class BazookaShootControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<ShootController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public ShootController Create(GameObject prefab, Transform target)
    {
        var bazookaShooter = parentGameObjectFactory.Create(prefab, target).GetComponent<BazookaShootController>();
        var collisionHandler = new ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory<PlayerController>(onSetCameraOnObjectListener, onAmmoCollideListener).Create();
        
        bazookaShooter.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, collisionHandler);

        return bazookaShooter;
    }

}
