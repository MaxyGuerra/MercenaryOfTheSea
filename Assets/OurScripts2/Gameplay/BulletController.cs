using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public EWeaponType weaponType;
    public bool destroyOnHit = true;
    public float bulletSpeed = 1;

    public float timeToDestroy = 5;

    //References to other scripts

    static public Rigidbody rb;

    static public int damage = 1;

    static public int bossDamage = 3;


    private void Awake()
    {
        
    }

    private void Start()
    {
       damage = WeaponsDatabase.Instance.GetWeaponDefinition(weaponType).baseDamage;

       // EnemyFollowBasicAI basicAI;

       // basicAI.Attack();
    }

    protected virtual void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
         
    }
   

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<IDamageable>()?.ApplyDamage(damage, weaponType);

        if(destroyOnHit)
        Destroy(gameObject);
 

    }
   
}
