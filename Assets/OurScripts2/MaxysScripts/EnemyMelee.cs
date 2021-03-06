﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase, IDamageable
{

    public int TiempoDeStun;
    private float Timer;
    private bool TimerOn = false;
    private AttributeBase EnemyHealthAttribute;

    void Start()
    {
        navAgent.stoppingDistance = 1;
        EnemyHealthAttribute = GetComponent<AttributeBase>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            navAgent.speed = 0;
            TimerOn = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StickyBall"))
        {
            navAgent.speed = 3;
        }
    }

    protected override void Attack()
    {

        return;
    }

    void Update()
    {
        AIBrain();

        if (TimerOn == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= TiempoDeStun)
            {
                navAgent.speed = 5;
                Timer = 0;
                enemyState = EnemyState.FOLLOW;
                TimerOn = false;
            }
        }

        if (EnemyHealthAttribute.currentValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
