﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraZoomController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float timeToGetCloser;
    public float timeToGetFurther;

    IEnumerator StartBattleAnimation()
    {
        var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();

        //camara zoom

        for (float i = 0; i <timeToGetCloser; i += Time.deltaTime)
        {
            transposer.m_FollowOffset = new Vector3(0, Mathf.Lerp(27, 30, i / timeToGetCloser), -20);
            yield return null;
        }


        //Wait for the camara
        yield return new WaitForSeconds(1);

        //Alejar la camara
        for (float i = 0; i < timeToGetFurther; i += Time.deltaTime)
        {

            transposer.m_FollowOffset = new Vector3(0, Mathf.Lerp(50, 30, i / timeToGetFurther), -20);
            yield return null;
        }

        transposer.m_FollowOffset = new Vector3(0, 37, -20);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(StartBattleAnimation());
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}