using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{

    [SerializeField] private EWeaponType WeaponType;
    [SerializeField] private float m_bulletSpeed = 2;
    [SerializeField] private int damage = 1;

    public float bulletSpeed { get { return m_bulletSpeed; } set { m_bulletSpeed = value; } }
    private int timeToDestroy = 5;

    [SerializeField] private bool DestroyOnHit = true;


    // Start is called before the first frame update
    void Start()
    {
        damage = WeaponsDatabase.Instance.GetWeaponDefinition(WeaponType).baseDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable>()?.ApplyDamage(damage, WeaponType);

        if (DestroyOnHit)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);

    }

    // Update is called once per frame
    void Update()
    {


    }
}

