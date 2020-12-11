using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : BulletController
{

    [SerializeField] private float delay = 3f;
    private bool hasExploted = false;

    //public GameObject explos

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Detonate()
    {
      
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& !hasExploted)
        {
            Detonate();
            Destroy(gameObject);
        }
    }
}
