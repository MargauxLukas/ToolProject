using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player Spaceship") && gameObject.name.Contains("Enemy Bullet"))
        {
            collision.gameObject.GetComponent<SpaceshipBehavior>().LoseLife();
        }
        else if (collision.gameObject.name.Contains("Enemy Spaceship") && gameObject.name.Contains("Player Bullet"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().LoseLife();
        }
    }
}
