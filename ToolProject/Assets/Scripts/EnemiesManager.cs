using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;

    public Transform hiddenSpawn;
    public EnemyBehavior[] enemiesList;
    public Transform enemiesSpawn;
    public EnemyBullet[] enemiesBullets;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    private void Start()
    {
        InitEnemy();
    }

    void Update()
    {
        
    }

    void InitEnemy()
    {
        foreach(EnemyBehavior enemy in enemiesList)
        {
            if (!enemy.isUsed)
            {
                enemy.isUsed = true;
                enemy.transform.position = enemiesSpawn.transform.position;
                Spawn(enemy);
            }
        }
    }

    void Spawn(EnemyBehavior enemy)
    {
        enemy.gameObject.SetActive(true);
    }
}
