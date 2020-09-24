using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum BossState { IDLE,FOLLOW,DEAD}
public class BossAIScript : MonoBehaviour
{

    NavMeshAgent navAgent;
    public float remainingDistance; 
    public Transform playerTarget;
    public bool isFollowingPlayer = false;

    public int enemyHealth = 3;
    public BossState bossState;

    public delegate void FBossDeadNotify(Transform BossTransform);
    public static event FBossDeadNotify OnBossDead;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ApplyDamage(int Damage)
    {
        if (bossState == BossState.DEAD) return;
        enemyHealth -= Damage;
        if (enemyHealth <= 0)
            SetDead();
    }    

    void SetDead()
    {
        bossState = BossState.DEAD;
        navAgent.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        OnBossDead?.Invoke(transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I'm following you");

            isFollowingPlayer = true;

        }
    }

    void FollowPlayer()
    {
        if (playerTarget ==null) return;

        if (!navAgent.SetDestination(playerTarget.position)) return;

        if (!navAgent.hasPath) return;
        remainingDistance = navAgent.remainingDistance;
    }

    void Brain()
    {
        switch(bossState)
        {
            case BossState.IDLE:

                break;
            case BossState.FOLLOW:
                if (isFollowingPlayer == true)
                {
                    FollowPlayer();
                }
                break;
            case BossState.DEAD:

                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) ApplyDamage(31);
        Brain();
       
    }
}
