using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    public float speed;
    public float spriteOffset;
    Vector2 direction;

    public int life;

    void Start()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        direction = new Vector2(x, 0).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - spriteOffset;
        min.x = min.x + spriteOffset;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.fixedDeltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        transform.position = pos;
    }

    public void LoseLife()
    {
        life--;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Lose life, Your life is now : " + life);
    }
}
