using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPeces : MonoBehaviour
{
    public GameObject peces;
    private bool PrimeraActi;

    private void Start()
    {
        peces.SetActive(false);
        PrimeraActi = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && PrimeraActi == false)
        {
            peces.SetActive(true);
            PrimeraActi = true;
        }
    }
}
