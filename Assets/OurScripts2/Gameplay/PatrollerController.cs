using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrollerController : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    public float minThresholdDistance = 1f;

    private int waypointIndex;
    private float dist;


    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        //transform.LookAt(waypoints[waypointIndex].position);

        navAgent.SetDestination(waypoints[waypointIndex].position);
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

        transform.LookAt(waypoints[waypointIndex].position);
    }


    void ChangeNextWaypoint()
    {
        IncreaseIndex();
        navAgent.SetDestination(waypoints[waypointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.remainingDistance < minThresholdDistance)
            ChangeNextWaypoint();

        else
        {
            return;
        }

       // dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        //if(dist < 0f)
        //{
        //    IncreaseIndex();
       // }

       // Patrol();
    }



    
}
