using UnityEngine;

public class InitAmmoControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AmmoController>
{
    [SerializeField]
    private AmmoControllerGameObjectFactory ammoControllerGameObjectFactory;
    private OnAmmoCollideListener onAmmoCollideListener;

    public void Init(OnAmmoCollideListener onAmmoCollideListener)
    {
        this.onAmmoCollideListener = onAmmoCollideListener;
    }

    public AmmoController Create(GameObject ammoPrefab, Transform emitPoint)
    {
        var ammoController = ammoControllerGameObjectFactory.Create(ammoPrefab, emitPoint);
        ammoController.Init(onAmmoCollideListener);

        return ammoController;
    }

}
