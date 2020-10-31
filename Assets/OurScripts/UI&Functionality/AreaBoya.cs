using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AreaBoya : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
