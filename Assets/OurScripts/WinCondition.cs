using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public BossAIScript boss;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") == true && (boss.isDead == true))
        {
            Debug.Log("Ganaste, yey");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
