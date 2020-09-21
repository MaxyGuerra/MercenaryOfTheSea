using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EEnemyState { IDLE, PATROL, FOLLOW, ATTACK, RETREAT }

public class EnemyFollowBasicAI : MonoBehaviour
{
    NavMeshAgent navAgent;
    public EEnemyState enemyState;
    public Transform Player;
    public float AttackDistance = 8;
    [Header("Debug AI")]
    public float remainingDistance;

    [Header("Attack Scripts")]
    public EnemyShotController enemyShot;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Attack()
    {
        if (Player == null)
        {
            //player is dead?
            enemyState = EEnemyState.IDLE;
            return;

        }


        print("Attack! (corutine?");

        enemyShot.canShoot = true;
    }
    void FollowPlayer()
    {
        if (Player == null) return;


        if (!navAgent.SetDestination(Player.position)) return;

        if (!navAgent.hasPath) return;
        remainingDistance = navAgent.remainingDistance;


        if (remainingDistance <= AttackDistance)
        {
            enemyState = EEnemyState.ATTACK;
            return;
        }



    }

    void AIBrain()
    {
        switch (enemyState)
        {
            case EEnemyState.IDLE:

                if (Player == null) return;

                enemyState = EEnemyState.FOLLOW;

                break;

            case EEnemyState.FOLLOW:

                FollowPlayer();

                break;

            case EEnemyState.ATTACK:

                Attack();

                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

        AIBrain();
    }
}


