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
    private new void OnTriggerEnter(Collider other)
    {
        enemyNavMesh = other.gameObject.GetComponent<NavMeshAgent>();

        enemyNavMesh.speed = enemySpeed;


        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.CompareTag("Enemy"))
        {

            enemySpeed = enemyReduceSpeed;

        }
    }


    
}
