using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Attack()
    {
        if (player == null)
        {
            //player is dead?
            enemyState = EnemyState.IDLE;
            return;
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
