using UnityEngine;

public class PlayerControllerRemover : MonoBehaviour, Remover<PlayerController>
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;

    public void Remove(PlayerController player)
    {
        player.OnSeleectWeaponListener = null;
        gameObjectRemover.Remove(player.gameObject);
    }

}
