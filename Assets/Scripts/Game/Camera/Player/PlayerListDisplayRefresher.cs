using System.Collections.Generic;
using UnityEngine;

public class PlayerListDisplayRefresher : MonoBehaviour, DisplayRefresher
{
    private Transform playerCamera;
    private List<PlayerController> playerList;

    public void Init(Transform playerCamera, List<PlayerController> playerList)
    {
        this.playerCamera = playerCamera;
        this.playerList = playerList;
    }
    
    public void RefreshDisplay()
    {
        playerList.ForEach(player =>
        {
            player.Camera = playerCamera;
            player.RefreshDisplay();
        });
    }

}
