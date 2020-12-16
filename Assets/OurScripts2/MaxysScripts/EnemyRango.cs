using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyRango : EnemyBase
{
    EnemyShotController EnemyShot;
    private float Timer;
    private bool TimerOn = false;
    private int TiempoDeProximidad = 2;

    // Start is called before the first frame update
    void Start()
    {
        navAgent.stoppingDistance = 12;
        AttackDistance = navAgent.stoppingDistance;
        EnemyShot = GetComponent<EnemyShotController>();
        EnemyShot.shootingDistance = navAgent.stoppingDistance + 2;
    }

    protected override void Attack()
    {
        if (player == null)
        {
            //player is dead?
            enemyState = EnemyState.IDLE;
            return;
        }

        EShootStatus shootStatus= EnemyShot.TryToShoot(player);


        TimerOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StickyBall"))
        {
            navAgent.speed = 3;
        }
    }

        // Update is called once per frame
        void Update()
    {
        AIBrain();

        if (TimerOn == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= TiempoDeProximidad)
            {
                Timer = 0;
                TimerOn = false;
                enemyState = EnemyState.FOLLOW;
            }
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
