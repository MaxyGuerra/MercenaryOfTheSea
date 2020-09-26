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
    public bool isDead = false;

    public int bossHealth = 3;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Harpoon"))
        {
            if (bossState == BossState.DEAD) return;

            bossHealth -= BulletController.damage;

            Destroy(other.gameObject);

            if (bossHealth <= 0)
            {
                bossHealth = 0;
                isDead = true;
            }
        }

        if (other.gameObject.CompareTag("Harpoon") && (isDead == true))
        {
            SetDead();
        }
    }


 
    void SetDead()
    {
        bossState = BossState.DEAD;
        navAgent.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        OnBossDead?.Invoke(transform);
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
        Brain();
       
    }
}
