using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBossWinCondition : MonoBehaviour
{
    public CanvasGroup winCanvas;

    public NewPlayerController playerReference;

    public GameObject compass;

    private AudioSource _audioSource;
    public AudioClip soundEfect;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {

            compass.gameObject.SetActive(false);

            _audioSource.PlayOneShot(soundEfect, 0.7F);

            Destroy(other.gameObject);

            playerReference.canMove = false;

            winCanvas.gameObject.SetActive(true);



        }
    }

}
