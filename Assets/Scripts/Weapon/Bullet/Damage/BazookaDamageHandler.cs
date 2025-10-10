using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BazookaDamageHandler : DamageHandler
{
    private OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener;
    private OnBulletCollideListener onBulletCollideListener;

    public BazookaDamageHandler(OnSetCameraOnShotPlayerListener onSetOnShotPlayerCameraListener, OnBulletCollideListener onBulletCollideListener)
    {
        this.onSetOnShotPlayerCameraListener = onSetOnShotPlayerCameraListener;
        this.onBulletCollideListener = onBulletCollideListener;
    }

    public void HandleDamage(Collision collision, Bullet bullet)
    {
        Vector3 collisionPoint = collision.contacts[0].point;

        List<PlayerController> hitPlayerList = Physics.OverlapSphere(collisionPoint, bullet.Radius)
            .Select(collider => collider.gameObject)
            .Select(gameObject => gameObject.GetComponent<PlayerController>())
            .Where(playerController => playerController != null)
            .ToList();
            
        if (hitPlayerList.Count > 0)
        {
            hitPlayerList.ForEach(player =>
            {
                int damage = new BazookaDamageCalculator(collisionPoint, player.transform.position).CalculateDamage(bullet);
                player.OnBulletCollideOnPlayer(new HitBullet(damage));
            });

            onSetOnShotPlayerCameraListener.OnSetCameraOnShotPlayer(hitPlayerList);
        }
        else
        {
            onBulletCollideListener.OnBulletCollide();
        }
    }

}
