using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StickyBullet : BulletController
{
    public float enemyReduceSpeed = 2.0f;
    private NavMeshAgent enemyNavMesh;
    private float enemySpeed;

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
        }

    }

}
