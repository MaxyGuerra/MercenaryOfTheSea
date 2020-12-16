using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public NewPlayerController thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<NewPlayerController>();    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            thePlayer.SetSpawnPoint(transform.position);
        }
    }
  
}
