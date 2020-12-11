using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StickyBullet : BulletController
{
    public float enemyReduceSpeed = 2.0f;
    private NavMeshAgent enemyNavMesh;
    private float enemySpeed;

    private float _timer;
    private bool isTimerOn = false;
    [SerializeField] private int reduceSpeedTime;

    private void Awake()
    {
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        enemyNavMesh = collision.gameObject.GetComponent<NavMeshAgent>();

        enemyNavMesh.speed = enemySpeed;

        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.GetComponent<IDamageable>() != null && collision.gameObject.CompareTag("Enemy"))
        {

            enemySpeed = enemyReduceSpeed;

            isTimerOn = true;
        }

    }

    private void Update()
    {
        if(isTimerOn == true)
        {
            _timer += Time.deltaTime;

            if(_timer >= reduceSpeedTime)
            {
                enemySpeed = 6;
                _timer = 0;
                isTimerOn = false;
            }
        }
    }

}
