using UnityEngine;

public class PlayerControllerRemover : MonoBehaviour, Remover<PlayerController>
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;

    public void Remove(PlayerController player)
    {
        // player.OnAmmoShotListener = null;
        // player.OnSetOnShotPlayerCameraListener = null;
        // player.OnBulletCollideListener = null;
        // player.OnPlayerKilledListener = null;

        gameObjectRemover.Remove(player.gameObject);
    }

}
