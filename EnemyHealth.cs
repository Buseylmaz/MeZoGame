using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth=50;
    EnemyAI enemy;
    
    void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    
    void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            Destroy(gameObject);
        }
    }

    public void ReduceHealth(float reduceHealth)//can düşürme için
    {
        enemyHealth -= reduceHealth;

        if (!enemy.isDead)
        {
            enemy.Hit();
        }
        if (enemyHealth <= 0)
        {
            enemy.Dead();
            Dead();
        }
    }

    void Dead()
    {
        enemy.canAttack = false;
        Destroy(gameObject,10f);
    }
}
