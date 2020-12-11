using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    public int TiempoDeStun;
    private float Timer;
    private bool TimerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent.stoppingDistance = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            navAgent.speed = 0;
            TimerOn = true;
        }
    }

    // Update is called once per frame
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
