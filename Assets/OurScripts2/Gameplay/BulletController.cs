using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{

    [SerializeField] protected EWeaponType WeaponType;
    [SerializeField] private float m_bulletSpeed = 2;
    [SerializeField] protected int damage = 1;

    public GameObject impactFX;
    public string[] targetTags;
    public float bulletSpeed { get { return m_bulletSpeed; } set { m_bulletSpeed = value; } }
    private int timeToDestroy = 5;

    [SerializeField] private bool DestroyOnHit = true;


    // Start is called before the first frame update
    void Start()
    {
        damage = WeaponsDatabase.Instance.GetWeaponDefinition(WeaponType).baseDamage;
    }

    public void ShootToDirection(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity=direction*bulletSpeed;
    }
    public void ShootToDirection(Vector3 direction,float shootSpeed)
    {
        GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        bool hitSucess=false;
        for (int i = 0; i < targetTags.Length; i++)
        {
          if(  other.CompareTag(targetTags[i]))
            {
                other.GetComponent<IDamageable>()?.ApplyDamage(damage, WeaponType);
                hitSucess=true;
            }
        }
     

        if (DestroyOnHit && hitSucess)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);

    }
 
}

