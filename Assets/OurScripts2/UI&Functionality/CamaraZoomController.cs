using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraZoomController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float timeToGetCloser;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator StartBattleAnimation()
    {
        var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();

        //camara zoom

        for (float i = 0; i <timeToGetCloser; i += Time.deltaTime)
        {
            transposer.m_FollowOffset = new Vector3(0, Mathf.Lerp(37, 30, i / timeToGetCloser), -20);
            yield return null;
        }


        //Wait for the camara
        yield return new WaitForSeconds(1);

        //Alejar la camara
        for (float i = 0; i < timeToGetCloser; i += Time.deltaTime)
        {

            transposer.m_FollowOffset = new Vector3(0, Mathf.Lerp(30, 37, i / timeToGetCloser), -20);
            yield return null;
        }

        transposer.m_FollowOffset = new Vector3(0, 37, -20);

        //Activar la batalla si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
