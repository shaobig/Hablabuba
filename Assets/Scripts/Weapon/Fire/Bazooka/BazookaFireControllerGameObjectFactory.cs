using System.Collections.Generic;
using UnityEngine;

public class BazookaFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<BazookaFireController>
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

    public BazookaFireController Create(GameObject prefab, Transform target)
    {
        var bazookaFireController = parentGameObjectFactory.Create(prefab, target).GetComponent<BazookaFireController>();
        var collisionHandler = new ExplosionCollisionContextMonoBehaviourCollisionHandlerFactory<PlayerController>(onSetCameraOnObjectListener, onAmmoCollideListener).Create();
        
        bazookaFireController.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, collisionHandler);

        return bazookaFireController;
    }

}
