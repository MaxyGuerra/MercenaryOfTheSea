using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private CheckPointMaster gm;
    private PlayerController playerReference;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<CheckPointMaster>();
        transform.position = gm.lastChackPointPos;
    }


}
