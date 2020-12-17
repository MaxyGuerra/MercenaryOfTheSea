using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBossWinCondition : MonoBehaviour
{
    public CanvasGroup winCanvas;

    public GameObject addonsIcons;

    public NewPlayerController playerReference;

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
            _audioSource.PlayOneShot(soundEfect, 0.7F);

            addonsIcons.gameObject.SetActive(false);

            Destroy(other.gameObject);

            playerReference.canMove = false;

            winCanvas.gameObject.SetActive(true);



        }
    }

}
