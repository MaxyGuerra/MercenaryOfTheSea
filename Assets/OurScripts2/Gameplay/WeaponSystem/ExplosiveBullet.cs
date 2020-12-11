using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : BulletController
{

    private bool hasExploted = false;
    public float explosionRadius=3f;

    public bool canDamagePlayer;


    //public GameObject explos

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Detonate()
    {
        if (hasExploted) return;

        hasExploted = true;

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].GetComponent<IDamageable>()?.ApplyDamage(damage, WeaponType);

        }

        if(impactFX)
        {
            Instantiate(impactFX, transform.position, Quaternion.identity);

        }


       Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (other.gameObject.GetComponent<IDamageable>() != null)
        {

            Detonate();
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.GetComponent<IDamageable>()!=null)
        {
            Detonate();

        }
        
    }
}
