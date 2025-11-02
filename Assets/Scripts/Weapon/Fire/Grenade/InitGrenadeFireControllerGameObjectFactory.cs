using System.Collections.Generic;
using UnityEngine;

public class InitGrenadeFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<GrenadeFireController>
{
    [SerializeField]
    private GrenadeFireControllerGameObjectFactory grenadeFireControllerGameObjectFactory;
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

    public GrenadeFireController Create(GameObject prefab, Transform target)
    {
        var grenadeFireController = grenadeFireControllerGameObjectFactory.Create(prefab, target);
        var collisionHandler = new ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory<PlayerController>(onSetCameraOnObjectListener, onAmmoCollideListener).Create();

        grenadeFireController.Init(collisionHandler, onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener);
        
        return grenadeFireController;
    }
    
}
