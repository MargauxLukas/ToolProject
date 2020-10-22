using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public bool move = false;
    public bool isShot = false;

    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - speed * Time.fixedDeltaTime);
        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < max.y) BulletReset();
    }

    public void BulletReset()
    {
        transform.position = Vector2.zero;
        isShot = false;
        gameObject.SetActive(false);

        transform.position = BulletManager.instance.hiddenSpawn.transform.position;
    }
}
