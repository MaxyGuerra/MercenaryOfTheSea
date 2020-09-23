using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeeleEnemyController : MonoBehaviour
{
    NavMeshAgent navMesh;
    public PlayerController player;
    public float newPlayerSpeed = 0;

    float timeStalled = 5;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             timeStalled -= Time.deltaTime;


            if(timeStalled >= 0)
            {

                player.moveSpeed = 0;

                Debug.Log("Enemy stopped" + "" + timeStalled + "secs");

            }
        }
       

    }

    private void OnCollisionExit(Collision collision)
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
