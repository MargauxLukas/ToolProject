using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public bool isShot = false;

    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y + speed * Time.fixedDeltaTime);
        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > max.y) BulletReset();  
    }

    public void BulletReset()
    {
        gameObject.SetActive(false);
        isShot = false;
        transform.position = BulletManager.instance.hiddenSpawn.transform.position;
    }
}
