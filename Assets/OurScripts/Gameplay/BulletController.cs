using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 1;

    public float timeToDestroy = 5;

    static public Rigidbody rb;

    static public int damage = 1;

    static public int bossDamage = 3;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, timeToDestroy);
    }
}
