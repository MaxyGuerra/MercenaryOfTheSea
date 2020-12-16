using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool checkpointReady;
    // Start is called before the first frame update
    void Start()
    {
 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (checkpointReady) return;
        checkpointReady = true;
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.SaveCheckpoint(transform.position);
        }
    }
  
}
