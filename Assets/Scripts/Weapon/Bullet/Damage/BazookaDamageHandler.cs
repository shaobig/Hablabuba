using System.Linq;
using UnityEngine;

public class BazookaDamageHandler : DamageHandler
{
    public void HandleDamage(Collision collision, Bullet bullet)
    {
        Vector3 collisionPoint = collision.contacts[0].point;

        Physics.OverlapSphere(collisionPoint, bullet.Radius)
            .Select(collider => collider.gameObject)
            .Select(gameObject => gameObject.GetComponent<PlayerController>())
            .Where(playerController => playerController != null)
            .ToList()
            .ForEach(player =>
            {
                int damage = new BazookaDamageCalculator(collisionPoint, player.transform.position).CalculateDamage(bullet);
                player.OnBulletCollideOnPlayer(new HitBullet(damage));
            });
    }

}
