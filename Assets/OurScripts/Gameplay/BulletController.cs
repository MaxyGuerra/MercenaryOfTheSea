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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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

       // transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        Destroy(gameObject, timeToDestroy);
    }
}
