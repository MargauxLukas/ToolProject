using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Renderer render;
    PlayerInstance player; 

    public float speed;
    public int life;

    public bool isUsed;
    public bool justShot;
    public float delay;

    public Transform bulletSpawn;

    void Start()
    {
        player = PlayerInstance.instance;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);
        transform.position = pos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            ResetEnemy();
        }

        if (render.isVisible && !justShot)
        {
            justShot = true;
            Shoot();
            StartCoroutine(AddDelay());
        }
    }

    void Shoot()
    {
        foreach (EnemyBullet bullet in EnemiesManager.instance.enemiesBullets)
        {
            if (!bullet.isShot)
            {
                bullet.isShot = true;
                bullet.transform.position = bulletSpawn.transform.position;
                bullet.gameObject.SetActive(true);
                return;
            }
        }
    }

    public void LoseLife()
    {

    }

    void ResetEnemy()
    {
        transform.position = EnemiesManager.instance.hiddenSpawn.transform.position;
        isUsed = false;
        gameObject.SetActive(false);
    }

    IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(delay);
        justShot = false;
    }
}
