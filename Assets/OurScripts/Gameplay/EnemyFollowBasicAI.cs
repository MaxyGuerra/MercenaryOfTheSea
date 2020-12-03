using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum EEnemyState { IDLE, PATROL, FOLLOW, ATTACK, RETREAT }

public class EnemyFollowBasicAI : MonoBehaviour
{
    
    NavMeshAgent navAgent;
    public EEnemyState enemyState;
    public HealthBar enemyHealthBar;
    public int enemyHealth = 3;
    private NavMeshAgent speedReference;
    private float timeToWait;

    public Transform player;
    public float AttackDistance = 8;
    [Header("Debug AI")]
    public float remainingDistance;
    
    // [Header("Attack Scripts")]

    // public bool thisEnemyShoot = false;
    // public EnemyShotController enemycannon;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        speedReference = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar.SetMaxHealth(enemyHealth);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHealth--;

            enemyHealthBar.SetHealth(enemyHealth);


            Destroy(other.gameObject);
            
        }

        //if (other.gameObject.CompareTag("StickyBall"))
        //{
          //  speedReference.speed = 2;

        //}
    }

    void Attack()
    {
        if (player == null)
        {
            //player is dead?
            enemyState = EEnemyState.IDLE;
            return;
        }
      
        print("Attack! (corutine?");

        //enemycannon.canShoot = true;
    }
    void FollowPlayer()
    {
        if (player == null) return;


        if (!navAgent.SetDestination(player.position)) return;

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

                if (player == null) return;

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

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}


