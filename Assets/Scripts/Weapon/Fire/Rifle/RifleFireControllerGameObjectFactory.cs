using System.Collections.Generic;
using UnityEngine;

public class RifleFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<RifleFireController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
    }

    public RifleFireController Create(GameObject prefab, Transform target)
    {
        var rifleFireController = parentGameObjectFactory.Create(prefab, target).GetComponent<RifleFireController>();
        // var collisionHandler = new RifleListenerCollisionHandlerFactory(onSetCameraOnObjectListener, onAmmoCollideListener, new ContextRifleForceApplierFactory(), new CollisionHandlerRifleDamageCalculatorFactory()).Create();
        
        // rifleFireController.Init(collisionHandler, onFireListener, onAmmoShotListener);

        return rifleFireController;
    }

}
