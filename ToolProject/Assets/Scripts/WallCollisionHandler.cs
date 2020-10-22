using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player Spaceship"))
        {
            Destroy(collision.gameObject);
            //timeset 0
            //Restart Game
        }
        else if (collision.gameObject.name.Contains("Bullet"))
        {
            if (collision.gameObject.name.Contains("Player"))
            {
                collision.gameObject.GetComponent<PlayerBullet>().BulletReset();
            }
            else if (collision.gameObject.name.Contains("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyBullet>().BulletReset();
            }
        }
    }
}
