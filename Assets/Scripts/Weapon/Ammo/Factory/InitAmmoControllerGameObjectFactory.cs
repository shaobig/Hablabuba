using UnityEngine;

public class InitAmmoControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AmmoController>
{
    [SerializeField]
    private AmmoControllerGameObjectFactory ammoControllerGameObjectFactory;
    private OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener;

    public void Init(OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        this.onAmmoCollideWithTerrainListener = onAmmoCollideWithTerrainListener;
    }

    public AmmoController Create(GameObject ammoPrefab, Transform emitPoint)
    {
        var ammoController = ammoControllerGameObjectFactory.Create(ammoPrefab, emitPoint);
        ammoController.Init(onAmmoCollideWithTerrainListener);

        return ammoController;
    }

}
