using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AreaBoya : MonoBehaviour
{
    public GameObject Bandera;

    // Start is called before the first frame update
    void Start()
    {
        Bandera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bandera.SetActive(true);
        }
    }
}
