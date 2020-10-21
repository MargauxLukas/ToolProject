using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    public Transform hiddenSpawn;
    public Transform[] bulletSpawns;
    public PlayerBullet[] playerBullets;

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
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < playerBullets.Length; i = i + 2)
            {
                ShootBullet(playerBullets[i], playerBullets[i+1]);
            }
        }
    }

    IEnumerator ShootBullet(PlayerBullet leftBullet, PlayerBullet rightBullet)
    {
        leftBullet.transform.position = bulletSpawns[0].transform.position;
        leftBullet.BulletMove();
        rightBullet.transform.position = bulletSpawns[1].transform.position;
        rightBullet.BulletMove();

        yield return new WaitForSeconds(.5f);
    }
}
