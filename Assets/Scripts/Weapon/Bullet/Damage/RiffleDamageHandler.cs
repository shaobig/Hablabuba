using UnityEngine;

public class RiffleDamageHandler : DamageHandler
{
    private const string PLAYER_TAG = "Player";

    public void HandleDamage(Collision collision, Bullet bullet)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            player.OnBulletCollideOnPlayer(new HitBullet(bullet.Damage));
        }
    }

}
