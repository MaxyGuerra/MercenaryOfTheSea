using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 1;

    public float timeToDestroy = 5;

    public bool isBreakRock = false;

    public bool isSlower = false;

    //References to other scripts

    static public Rigidbody rb;

    static public int damage = 1;

    static public int bossDamage = 3;


    private void Awake()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if((isBreakRock = true) && other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }

        if ((isSlower = true) && other.gameObject.CompareTag("Enemy"))
        {
           
        }
    }
    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, timeToDestroy);
    }
}
