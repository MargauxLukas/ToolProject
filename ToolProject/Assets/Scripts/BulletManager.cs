using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    public Transform hiddenSpawn;
    public Transform bulletSpawn;
    public PlayerBullet[] playerBullets;

    public bool pressed;
    public float delay;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !pressed)
        {
            pressed = true;
            ShootBullet();
            StartCoroutine(AddDelay());
        }
    }

    void ShootBullet()
    {
        foreach(PlayerBullet bullet in playerBullets)
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

    IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(delay);
        pressed = false;
    }
}
