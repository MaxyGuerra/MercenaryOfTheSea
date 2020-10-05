using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public int speed;
    public bool puedeMoverse = false;


    void Move()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(puedeMoverse == true)
        {
            Move();
        }
    }
}
