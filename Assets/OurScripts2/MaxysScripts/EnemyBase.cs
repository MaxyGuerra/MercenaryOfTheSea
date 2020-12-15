﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum EnemyState { IDLE, PATROL, FOLLOW, ATTACK, RETREAT }
public class EnemyBase : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public EnemyState enemyState;
    public HealthBar enemyHealthBar;
    public int enemyHealth = 3;
    private NavMeshAgent speedReference;
    public int CampoDeVision;

    public Transform player;
    public float AttackDistance = 8;
    [Header("Debug AI")]
    public float remainingDistance;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        speedReference = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
        }
    }

    protected virtual void Attack()
    {
        if (player == null)
        {
            //player is dead?
            enemyState = EnemyState.IDLE;
            return;
        }
    }

    void FollowPlayer()
    {
        if (player == null) return;

        if (!navAgent.SetDestination(player.position)) return;

        if (!navAgent.hasPath) return;
        remainingDistance = navAgent.remainingDistance;

        if (remainingDistance <= CampoDeVision)
        {
            navAgent.speed = 5;
        }

        if (remainingDistance <= AttackDistance)
        {
            enemyState = EnemyState.ATTACK;
            return;
        }

    }

    protected virtual void AIBrain()
    {
        switch (enemyState)
        {
            case EnemyState.IDLE:

                if (player == null) return;

                enemyState = EnemyState.FOLLOW;

                break;

            case EnemyState.FOLLOW:

                FollowPlayer();

                break;

            case EnemyState.ATTACK:

                Attack();

                break;

        }
    }

    void Update()
    {
        AIBrain();

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
