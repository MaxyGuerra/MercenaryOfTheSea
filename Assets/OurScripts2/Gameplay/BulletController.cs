using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{

    [SerializeField] protected EWeaponType WeaponType;
    [SerializeField] private float m_bulletSpeed = 2;
    [SerializeField] protected int damage = 1;

    public GameObject impactFX;

    public float bulletSpeed { get { return m_bulletSpeed; } set { m_bulletSpeed = value; } }
    private int timeToDestroy = 5;

    [SerializeField] private bool DestroyOnHit = true;


    // Start is called before the first frame update
    void Start()
    {
        damage = WeaponsDatabase.Instance.GetWeaponDefinition(WeaponType).baseDamage;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable>()?.ApplyDamage(damage, WeaponType);

        if (DestroyOnHit)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);

    }
 
}

