using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum EEnemyState { IDLE, PATROL, FOLLOW, ATTACK, RETREAT }

public class EnemyFollowBasicAI : MonoBehaviour,IDamageable
{
    
    NavMeshAgent navAgent;
    public EEnemyState enemyState;
    public HealthBar enemyHealthBar; 
    private float timeToWait;

    public Transform player;
    public float AttackDistance = 8;
    [Header("Debug AI")]
    public float remainingDistance;
    public bool hasPath; 

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
         remainingDistance = Mathf.Infinity;

       
    }
   
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

   
    

    public void DestroyShip()
    {
        Destroy(gameObject);
    }

    public void AttackWithParams()
    {

    }

   // [Obsolete("Esto va a ser borrado en versiones futuras asi que reemplazar por AttackWithParams",true)]
    public virtual void Attack()
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
    private void OnDrawGizmos()
    {
        if (!navAgent) return;
        Gizmos.DrawLine(navAgent.transform.position, navAgent.pathEndPosition);
        Gizmos.DrawWireSphere(navAgent.pathEndPosition, 1);
    }

    public NavMeshPathStatus pathStatus;
    void DebugAI()
    {
        hasPath = navAgent.hasPath;
        pathStatus = navAgent.pathStatus;
    }
    void AIBrain()
    {
#if UNITY_EDITOR
        DebugAI();
#endif


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

       
    }

    public void ApplyDamage(float Damage, EWeaponType weaponType = EWeaponType.None)
    {

        GetComponent<AttributeBase>().SubtractToValue(Damage);

    }
}


