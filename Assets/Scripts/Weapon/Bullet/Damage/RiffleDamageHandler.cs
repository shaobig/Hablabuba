using System.Collections.Generic;
using UnityEngine;

public class RiffleDamageHandler : DamageHandler
{
    private const string PLAYER_TAG = "Player";

    private OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener;
    private OnBulletCollideListener onBulletCollideListener;

    public RiffleDamageHandler(OnSetCameraOnShotPlayerListener onSetCameraOnShotPlayerListener, OnBulletCollideListener onBulletCollideListener)
    {
        this.onSetCameraOnShotPlayerListener = onSetCameraOnShotPlayerListener;
        this.onBulletCollideListener = onBulletCollideListener;
    }

    public void HandleDamage(Collision collision, Bullet bullet)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            player.OnBulletCollideOnPlayer(new HitBullet(bullet.Damage));

            onSetCameraOnShotPlayerListener.OnSetCameraOnShotPlayer(new List<PlayerController> { player });
        }
        else
        {
            onBulletCollideListener.OnBulletCollide();
        }
    }

}
