﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBossesWinCondition : MonoBehaviour
{
    public GameObject firstZone;

    private int numberOfBossesInBase;
    public CanvasGroup canvasWin;

    public GameObject particleFX;

    public NewPlayerController playerReference;

    public GameObject compass;

    private AudioSource _audioSource;
    public AudioClip soundEfect1;
    public AudioClip soundEfect2;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Boss"))
        {
            compass.gameObject.SetActive(false);

            Instantiate(particleFX, transform.position, Quaternion.identity);

            numberOfBossesInBase++;


            Destroy(other.gameObject);

            if (numberOfBossesInBase == 1)
            {
                _audioSource.PlayOneShot(soundEfect1, 0.7F);


                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(firstZone);
               

            }

            else if (numberOfBossesInBase == 2)
            {
                compass.gameObject.SetActive(false);

                _audioSource.PlayOneShot(soundEfect2, 0.7F);

                playerReference.canMove = false;

                canvasWin.gameObject.SetActive(true);

            }


        }
    }
}
