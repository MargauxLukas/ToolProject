using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            if (gameObject.name.Contains("Player"))
            {
                gameObject.GetComponent<SpaceshipBehavior>().LoseLife();
            }
            else if (gameObject.name.Contains("Enemy"))
            {
                gameObject.GetComponent<EnemyBehavior>().LoseLife();
            }
        }
    }
}
