using UnityEngine;

public class RifleFireControllerCreator : MonoBehaviour, Creator<RifleFireController>
{
    [SerializeField]
    private ParentObjectCreator parentObjectCreator;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
    }

    public RifleFireController Create(GameObject prefab, Transform target)
    {
        var rifleFireController = parentObjectCreator.Create(prefab, target).GetComponent<RifleFireController>();
        var collisionHandler = new RifleListenerCollisionHandlerFactory(onSetCameraOnShotPlayerListener, onAmmoCollideListener, new ContextRifleForceApplierFactory(), new RifleDamageCalculatorFactory()).Create();
        
        rifleFireController.Init(collisionHandler, onFireListener, onAmmoShotListener);

        return rifleFireController;
    }

}
