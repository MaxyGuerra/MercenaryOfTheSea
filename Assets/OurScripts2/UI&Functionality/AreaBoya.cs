using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AreaBoya : MonoBehaviour
{
    public GameObject Bandera;
    public GameObject particles;
    private AudioSource _audioSource;
    public AudioClip soundEfect;
    // Start is called before the first frame update
    void Start()
    {
        Bandera.SetActive(false);
        _audioSource= GetComponent<AudioSource>();
    }

    

 private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bandera.SetActive(true);

           Instantiate(particles, transform.position, Quaternion.identity);

            _audioSource.PlayOneShot(soundEfect, 0.7F);
        }
    }
}
