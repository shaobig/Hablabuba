using UnityEngine;

public class BazookaFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<BazookaFireController>
{
    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener,
        OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public BazookaFireController Create(GameObject prefab, Transform target)
    {
        var bazookaFireController = parentGameObjectFactory.Create(prefab, target).GetComponent<BazookaFireController>();
        var collisionHandler = new ExplosionListenerCollisionHandler(onSetCameraOnShotPlayerListener, onAmmoCollideListener, new ContextExplosionForceApplierFactory(), new ExplosionRadiusDamageCalculatorFactory());
        
        bazookaFireController.Init(onWeaponProgressBarChangeValueListener, onFireListener, onAmmoShotListener, collisionHandler);

        return bazookaFireController;
    }

}
