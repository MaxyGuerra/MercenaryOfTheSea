using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum BossState { IDLE,FOLLOW}
public class BossAIScript : MonoBehaviour
{

    NavMeshAgent navAgent;
    public float remainingDistance; 
    public Transform playerTarget;
    public bool isFollowingPlayer = false;

    public int enemyHealth = 3;
  



    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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


    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer == true)
        {
            FollowPlayer();
        }
    }
}
