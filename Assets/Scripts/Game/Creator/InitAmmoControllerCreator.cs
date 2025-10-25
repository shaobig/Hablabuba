using UnityEngine;

public class InitAmmoControllerCreator : MonoBehaviour, Creator<AmmoController>
{
    [SerializeField]
    private AmmoControllerCreator ammoControllerCreator;
    private OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener;

    public void Init(OnAmmoCollideWithTerrainListener onAmmoCollideWithTerrainListener)
    {
        this.onAmmoCollideWithTerrainListener = onAmmoCollideWithTerrainListener;
    }

    public AmmoController Create(GameObject ammoPrefab, Transform emitPoint)
    {
        var ammoController = ammoControllerCreator.Create(ammoPrefab, emitPoint);
        ammoController.Init(onAmmoCollideWithTerrainListener);

        return ammoController;
    }

}
