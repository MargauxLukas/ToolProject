using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletMove()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y + speed * Time.fixedDeltaTime);
        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y) Destroy(gameObject);      //later make it move to it start pos
    }
}
