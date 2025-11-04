using System.Collections.Generic;
using UnityEngine;

public class RifleFireControllerGameObjectFactory : MonoBehaviour, GameObjectFactory<AimShootController>
{
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private ParentGameObjectFactory parentGameObjectFactory;
    private OnAimTakenListener onAimTakenListener;
    private OnFireListener onFireListener;
    private OnAmmoShotListener onAmmoShotListener;
    private OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener;
    private OnNextStepPreparedListener onAmmoCollideListener;

    public void Init(
        OnAimTakenListener onAimTakenListener,
        OnFireListener onFireListener,
        OnAmmoShotListener onAmmoShotListener,
        OnSetCameraOnObjectListener<List<PlayerController>> onSetCameraOnObjectListener,
        OnNextStepPreparedListener onAmmoCollideListener)
    {
        this.onAimTakenListener = onAimTakenListener;
        this.onFireListener = onFireListener;
        this.onAmmoShotListener = onAmmoShotListener;
        this.onAmmoCollideListener = onAmmoCollideListener;
        this.onSetCameraOnObjectListener = onSetCameraOnObjectListener;
    }

    public AimShootController Create(GameObject prefab, Transform target)
    {
        var rifleShooter = parentGameObjectFactory.Create(prefab, target).GetComponent<RifleFireController>();
        var collisionHandler = new RifleCollisionContextMonoBehaviourCollisionHandlerFactory<PlayerController>(PLAYER_TAG, onSetCameraOnObjectListener, onAmmoCollideListener).Create();
        
        rifleShooter.Init(collisionHandler, onAimTakenListener, onFireListener, onAmmoShotListener);

        return rifleShooter;
    }

}
