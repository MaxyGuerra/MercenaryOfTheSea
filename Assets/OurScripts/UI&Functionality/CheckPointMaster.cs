using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointMaster : MonoBehaviour
{
    private CheckPointMaster instance;
    public Vector3 lastChackPointPos;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
