using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public bool move = false;
    public bool isShot = false;

    void Start()
    {

    }

    void Update()
    {
        if (move)
        {
            Vector2 pos = transform.position;
            pos = new Vector2(pos.x, pos.y + speed * Time.fixedDeltaTime);
            transform.position = pos;

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if (transform.position.y > max.y) BulletReset();                  //later make it move to it start pos
        }   
    }

    public void BulletMove()
    {
        move = true;
    }

    public void BulletReset()
    {
        transform.position = Vector2.zero;
        move = false;

        transform.position = BulletManager.instance.transform.position;
    }
}
