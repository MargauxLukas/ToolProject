using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Spaceship"))
        {
            Debug.Log("pouet");
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyBehavior>().ResetEnemy();
        }
    }
}
